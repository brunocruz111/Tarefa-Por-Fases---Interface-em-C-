using System;
using System.Threading;
using System.Threading.Tasks;
using Fase9.Domain;

namespace Fase9.Services
{
    public class DataPumpService<T>
    {
        private readonly IAsyncReader<T> _reader;
        private readonly IAsyncWriter<T> _writer;
        private readonly IClock _clock;

        public DataPumpService(IAsyncReader<T> reader, IAsyncWriter<T> writer, IClock clock)
        {
            _reader = reader;
            _writer = writer;
            _clock = clock;
        }

        public async Task<int> RunAsync(CancellationToken ct)
        {
            int successCount = 0;

            try
            {
                // Consome o stream assíncrono (IAsyncEnumerable)
                await foreach (var item in _reader.ReadAllAsync(ct))
                {
                    int attempts = 0;
                    while (true)
                    {
                        ct.ThrowIfCancellationRequested();
                        attempts++;

                        try
                        {
                            await _writer.WriteAsync(item, ct);
                            successCount++;
                            break; // Sucesso, sai do loop de retry e vai para o próximo item
                        }
                        catch (Exception ex) when (attempts <= 3) // Política: Tenta até 3 vezes
                        {
                            // Em um cenário real, aqui usaríamos await Task.Delay(...)
                            // Mas para teste determinístico, apenas logamos ou verificamos o Clock
                            Console.WriteLine($"[LOG] Falha na tentativa {attempts}. Retentando... (Erro: {ex.Message})");
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("[LOG] Operação cancelada durante o processamento.");
                // Propaga ou engole dependendo da regra. Aqui retornamos o parcial.
                return successCount; 
            }

            return successCount;
        }
    }
}