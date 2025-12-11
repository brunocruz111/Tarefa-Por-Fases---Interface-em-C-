using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Phase09AsyncDoubles.Domain;
using Phase09AsyncDoubles.Domain.Contracts;

namespace Phase09AsyncDoubles.Infrastructure;

public class JsonAsyncRepository : IAsyncRepository<Appointment>
{
    private readonly string _path;
    private static readonly JsonSerializerOptions _opts = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    public JsonAsyncRepository(string path) => _path = path;

    public async IAsyncEnumerable<Appointment> StreamAllAsync(CancellationToken ct = default)
    {
        if (!File.Exists(_path)) yield break;

        using var stream = File.OpenRead(_path);
        
        // DeserializeAsyncEnumerable é a chave para ler streams de JSON gigantes sem carregar tudo na RAM
        var items = JsonSerializer.DeserializeAsyncEnumerable<Appointment>(stream, _opts, ct);
        
        await foreach (var item in items.WithCancellation(ct))
        {
            if (item != null) yield return item;
        }
    }

    public async Task AddAsync(Appointment entity, CancellationToken ct = default)
    {
        // Implementação simplificada: Lê tudo, adiciona e grava (para fins didáticos)
        var list = new List<Appointment>();
        await foreach (var item in StreamAllAsync(ct)) list.Add(item);
        
        list.Add(entity);

        using var stream = File.Create(_path);
        await JsonSerializer.SerializeAsync(stream, list, _opts, ct);
    }
}