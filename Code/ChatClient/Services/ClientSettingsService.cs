using ChatShared; 

namespace ChatClient.Services
{
    public class ClientSettingsService
    {
        // Giấu tên file ở đây để Tuyến và Hùng không cần quan tâm đến nó
        private readonly string _configFilePath = "client_settings.json";

        public ClientSettings Load()
        {
            // Tận dụng SettingsManager dùng chung của team
            return SettingServices.Load<ClientSettings>(_configFilePath);
        }

        public void Save(ClientSettings config)
        {
            // Tận dụng SettingsManager dùng chung của team
            SettingServices.Save(config, _configFilePath);
        }
    }
}