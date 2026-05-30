using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatShared.Models.Settings
{
    internal class ServerConfig
    {
        public int Port { get; set; } = 1111;                    
        public int MaxClients { get; set; } = 67;                

        
        public bool EnableLogging { get; set; } = true;         
        public string LogFilePath { get; set; } = "";
    }
}
