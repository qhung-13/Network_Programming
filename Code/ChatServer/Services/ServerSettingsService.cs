using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatShared;


namespace ChatServer.Services
{
    internal class ServerSettingsService
    {

        private readonly string _configFilePath = "server_settings.json";

        public ServerSettings Load()
        {
            // Tận dụng SettingsManager dùng chung của team
            return SettingServices.Load<ServerSettings>(_configFilePath);
        }

        public void Save(ServerSettings config)
        {
            // Tận dụng SettingsManager dùng chung của team
            SettingServices.Save(config, _configFilePath);
        }
    }


}
