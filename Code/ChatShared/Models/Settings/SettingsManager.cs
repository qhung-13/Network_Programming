using System.IO;
using System.Text.Json;

public static class SettingsManager
{
  
    public static T LoadConfig<T>(string configPath) where T : new()
    {
        if (!File.Exists(configPath))
        {
            var defaultSettings = new T();
            SaveConfig(defaultSettings, configPath); 
            return defaultSettings;
        }

        string json = File.ReadAllText(configPath);
        return JsonSerializer.Deserialize<T>(json);
    }


    public static void SaveConfig<T>(T settings, string configPath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(settings, options);
        File.WriteAllText(configPath, json);
    }
}