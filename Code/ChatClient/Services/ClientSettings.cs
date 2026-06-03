using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Services
{
    public class ClientSettings
    {
        public string Username { get; set; } = "Your Mom";          
        public string ServerIP { get; set; } = "";      
        public int Port { get; set; } = 8888;                    
        public string LastRoom { get; set; } = "";        
        public bool AutoReconnect { get; set; } = true;

        
        public bool EnableNotifications { get; set; } = true;    
        public bool EnableSound { get; set; } = true;
    }
}
