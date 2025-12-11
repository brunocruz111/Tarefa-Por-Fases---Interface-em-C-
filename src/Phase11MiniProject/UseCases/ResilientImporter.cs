using System;
using System.Threading;
using System.Threading.Tasks;
using Phase09AsyncDoubles.Domain;
using Phase09AsyncDoubles.Domain.Contracts;

namespace Phase09AsyncDoubles.UseCases;

public class ResilientImporter
{
    private readonly IAsyncRepository<Appointment> _source;
    private readonly IAsyncRepository<Appointment> _destination;
    private readonly IClock _clock;

    public ResilientImporter(
        IAsyncRepository<Appointment> source, 
        IAsyncRepository<Appointment> destination, 
        IClock clock)
    {
        _source = source;
        _destination = destination;
        _clock = clock;
    }

    // Lê do Source e tenta gravar no Destination com retentativa
    public async Task<int> ImportAsync(CancellationToken ct)
    {
        int successCount = 0;
        int maxRetries = 3;

        try
        {
            // Percorre o Stream (assíncrono)
            await foreach (var item in _source.StreamAllAsync(ct))
            {
                bool saved = false;
                int attempts = 0;

                while (!saved && attempts < maxRetries)
                {
                    try
                    {
                        attempts++;
                        await _destination.AddAsync(item, ct);
                        saved = true;
                        successCount++;
                    }
                    catch (Exception)
                    {
                        if (attempts >= maxRetries) throw; // Desiste após 3 tentativas

                        // Backoff Exponencial (espera 1s, 2s, 4s...)
                        // Graças ao IClock, no teste isso será instantâneo!
                        var waitTime = TimeSpan.FromSeconds(Math.Pow(2, attempts));
                        await _clock.Delay(waitTime, ct);
                    }
                }
            }
        }
        catch (OperationCanceledException)
        {
            // Opcional: Logar cancelamento
            // Retorna o que conseguiu processar até o cancelamento
            return successCount; 
        }

        return successCount;
    }
}