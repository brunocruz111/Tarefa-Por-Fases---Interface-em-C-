using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fase8.Infra
{
    internal sealed class JsonFileStore<T> where T : class, new()
    {
        private readonly string _path;
        private static readonly JsonSerializerOptions _opts = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true
        };

        public JsonFileStore(string path) => _path = path;

        public List<T> Load()
        {
            if (!File.Exists(_path)) return new();
            var json = File.ReadAllText(_path);
            if (string.IsNullOrWhiteSpace(json)) return new();
            return JsonSerializer.Deserialize<List<T>>(json, _opts) ?? new();
        }

        public void Save(List<T> list)
        {
            var dir = Path.GetDirectoryName(_path);
            if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var json = JsonSerializer.Serialize(list, _opts);
            File.WriteAllText(_path, json);
        }

        public string Path => _path;
    }
}
