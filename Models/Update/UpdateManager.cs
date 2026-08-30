using Control.Models.Update;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;

public class UpdateManager
{
    // URL Raw de tu repositorio público de distribución
    private const string VersionUrl = "https://raw.githubusercontent.com/Control-PAM-Software/Control-PAM-Dist/refs/heads/main/version.json";

    // Cache local del version.json (misma carpeta que SettingSys.xml)
    private static readonly string CachePath = Path.Combine(Application.StartupPath, "Settings", "version.json");

    // Instancia única de HttpClient (Recomendado en .NET)
    private static readonly HttpClient _httpClient = new HttpClient();

    public UpdateManager()
    {
        // Configuramos para que no use caché y siempre traiga el JSON real
        if (_httpClient.DefaultRequestHeaders.CacheControl == null)
        {
            _httpClient.DefaultRequestHeaders.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue { NoCache = true };
        }
    }

    // Ahora este método solo consulta y compara. 
    // Devuelve el objeto UpdateInfo si hay actualización, o null si no hay nada.
    public async Task<UpdateInfo?> CheckForUpdatesAsync()
    {
        try
        {
            var remoteData = await GetRemoteVersionAsync();
            if (remoteData == null) return null;

            Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version!;
            Version newVersion = new Version(remoteData.version);

            if (newVersion > currentVersion)
            {
                return remoteData; // Retornamos la info para que la UI la use
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error en UpdateManager: {ex.Message}");
        }
        return null;
    }

    // Para el diálogo "Acerca de": prioriza el cache local; si no existe, lo trae de GitHub.
    public async Task<UpdateInfo?> GetChangesetAsync()
    {
        var cached = LoadCache();
        if (cached != null) return cached;

        var remote = await GetRemoteVersionAsync();
        if (remote != null)
        {
            await SaveCacheAsync(remote);
            return remote;
        }
        return null;
    }

    // Guarda el version.json descargado en Settings\version.json
    public async Task SaveCacheAsync(UpdateInfo data)
    {
        try
        {
            string dir = Path.GetDirectoryName(CachePath)!;
            Directory.CreateDirectory(dir);
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(CachePath, json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error al guardar cache: {ex.Message}");
        }
    }

    // Lee el version.json cacheado localmente (null si no existe o es inválido)
    public UpdateInfo? LoadCache()
    {
        try
        {
            if (!File.Exists(CachePath)) return null;
            string json = File.ReadAllText(CachePath);
            return JsonSerializer.Deserialize<UpdateInfo>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error al leer cache: {ex.Message}");
            return null;
        }
    }

    private async Task<UpdateInfo?> GetRemoteVersionAsync()
    {
        try
        {
            string json = await _httpClient.GetStringAsync(VersionUrl);
            return JsonSerializer.Deserialize<UpdateInfo>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        catch { return null; }
    }

    // Este método solo descarga y ejecuta. La decisión de llamarlo es de la UI.
    public async Task ExecuteUpdateAsync(UpdateInfo data)
    {
        string tempPath = Path.Combine(Application.StartupPath, "Update", "ControlPAM_Setup.exe");
        byte[] fileBytes = await _httpClient.GetByteArrayAsync(data.url_download);
        await File.WriteAllBytesAsync(tempPath, fileBytes);

        Process.Start(new ProcessStartInfo { FileName = tempPath, UseShellExecute = true });

        // Recién acá (con el instalador lanzado) se pisa el cache con el nuevo changelog.
        // Si la actualización se cancela o falla antes, el cache queda intacto.
        await SaveCacheAsync(data);

        Application.Exit();
    }
}