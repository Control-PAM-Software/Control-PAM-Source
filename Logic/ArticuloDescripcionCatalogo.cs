using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Control.Logic
{
    public static class ArticuloDescripcionCatalogo
    {
        private static readonly object _lock = new();
        private static Dictionary<string, string>? _cache;
        private static DateTime _lastLoad = DateTime.MinValue;
        private static readonly TimeSpan _ttl = TimeSpan.FromMinutes(5);

        private static string GetCatalogPath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string localAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Control");
            string userPath = Path.Combine(localAppData, "articulos_descripcion.json");
            string controlDbPath = Path.Combine(baseDir, "ControlDb", "articulos_descripcion.json");
            string controlDbDevPath = Path.Combine(baseDir, "..", "..", "..", "ControlDb", "articulos_descripcion.json");
            string controlDbDevResolved = Path.GetFullPath(controlDbDevPath);

            if (File.Exists(userPath))
            {
                return userPath;
            }
            if (File.Exists(controlDbPath))
            {
                return controlDbPath;
            }
            if (File.Exists(controlDbDevResolved))
            {
                return controlDbDevResolved;
            }
            return userPath;
        }

        public static Dictionary<string, string> Cargar()
        {
            lock (_lock)
            {
                string path = GetCatalogPath();
                if (_cache != null && DateTime.Now - _lastLoad < _ttl && File.Exists(path))
                {
                    try
                    {
                        var info = new FileInfo(path);
                        if (info.LastWriteTime <= _lastLoad)
                        {
                            return _cache;
                        }
                    }
                    catch { }
                }

                var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                try
                {
                    if (File.Exists(path))
                    {
                        string json = File.ReadAllText(path);
                        var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                        if (dict != null)
                        {
                            foreach (var kv in dict)
                            {
                                if (!string.IsNullOrWhiteSpace(kv.Key))
                                {
                                    result[kv.Key.Trim()] = kv.Value?.Trim() ?? string.Empty;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    // Si falla la carga, devolvemos diccionario vacío (no bloquea el reporte)
                }

                _cache = result;
                _lastLoad = DateTime.Now;
                return _cache;
            }
        }

        public static string ObtenerDescripcion(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                return string.Empty;
            }
            var dict = Cargar();
            return dict.TryGetValue(codigo.Trim(), out string? desc) ? desc ?? string.Empty : string.Empty;
        }

        public static void InvalidarCache()
        {
            lock (_lock)
            {
                _cache = null;
                _lastLoad = DateTime.MinValue;
            }
        }
    }
}
