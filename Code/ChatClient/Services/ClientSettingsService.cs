using System.Text.Json;

namespace ChatClient.Services;

public class ClientSettingsService
{
    private readonly string _configFilePath = "client_settings.json";

    public ClientSettings Load()
    {
        try
        {
            if (!File.Exists(_configFilePath))
                return new ClientSettings();

            var json = File.ReadAllText(_configFilePath);
            return JsonSerializer.Deserialize<ClientSettings>(json)
                   ?? new ClientSettings();
        }
        catch
        {
            return new ClientSettings();
        }
    }

    public void Save(ClientSettings config)
    {
        try
        {
            var json = JsonSerializer.Serialize(config,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_configFilePath, json);
        }
        catch { }
    }
}