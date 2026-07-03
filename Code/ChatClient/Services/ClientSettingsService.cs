using System.IO;
using System.Text.Json;

namespace ChatClient.Services;

/// <summary>
/// Service responsible for persisting and retrieving client configuration data.
/// Handles JSON serialization and provides safe fallback mechanisms.
/// </summary>
public class ClientSettingsService
{
    #region Fields

    // The local file path where user preferences are stored.
    private readonly string _configFilePath = "client_settings.json";

    #endregion

    #region Public Methods

    /// <summary>
    /// Loads the client settings from the local JSON configuration file.
    /// Returns default settings if the file does not exist or is corrupted.
    /// </summary>
    /// <returns>A populated ClientSettings instance.</returns>
    public ClientSettings Load()
    {
        try
        {
            // Return a fresh instance with default values if this is the first run
            if (!File.Exists(_configFilePath))
            {
                return new ClientSettings();
            }

            var json = File.ReadAllText(_configFilePath);

            // Deserialize the JSON payload. Fallback to a new instance if deserialization yields null.
            return JsonSerializer.Deserialize<ClientSettings>(json) ?? new ClientSettings();
        }
        catch
        {
            // Silently swallow I/O or parsing exceptions (e.g., corrupted JSON or access denied) 
            // and provide a clean slate with default settings to prevent application crashes.
            return new ClientSettings();
        }
    }

    /// <summary>
    /// Serializes the current settings model and writes it to the local configuration file.
    /// </summary>
    /// <param name="config">The settings object to be saved.</param>
    public void Save(ClientSettings config)
    {
        try
        {
            // WriteIndented ensures the generated JSON is human-readable and easily debuggable
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(config, options);

            File.WriteAllText(_configFilePath, json);
        }
        catch
        {
            // Intentionally swallowed: A failure to save user preferences (e.g., file locked) 
            // is non-critical and should not terminate the core application flow.
        }
    }

    #endregion
}