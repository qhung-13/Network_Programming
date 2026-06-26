using System.IO;
using System.Text.Json;

public static class SettingServices
{
  
    public static T Load<T>(string configPath) where T : new()
    {
        if (!File.Exists(configPath))
        {
            var defaultSettings = new T();
            Save(defaultSettings, configPath); 
            return defaultSettings;
        }

        string json = File.ReadAllText(configPath);
        return JsonSerializer.Deserialize<T>(json);
    }


    public static void Save<T>(T settings, string configPath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(settings, options);
        File.WriteAllText(configPath, json);
    }
}