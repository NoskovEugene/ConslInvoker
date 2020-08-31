using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using UI.MessengerUI.Configurations;


namespace UI.MessengerUI
{
    public class MessengerManager
    {
        public Configuration Configuration { get; private set; }

        public void SetConfiguration(Configuration configuration)
        {
            Configuration = configuration;
        }

        public void SetConfiguration(IConfigurationSection section)
        {
            
        }

        public void SetConfigurationFromNLog(IConfigurationSection section)
        {

        }

        public IMessenger GetMessenger()
        {
            return new Messenger(Configuration);
        }
    }
}