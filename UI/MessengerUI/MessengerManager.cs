using Microsoft.Extensions.Configuration;
using UI.MessengerUI.Configurations;
using UI.MessengerUI.Managers;

namespace UI.MessengerUI
{
    public static class MessengerManager
    {
        private static Configuration Configuration;

        private static MessageManager MessageManager;        

        public static void SetConfiguration(Configuration configuration)
        {
            Configuration = configuration;
            MessageManager = new MessageManager(Configuration);
        }

        public static void SetConfiguration(IConfigurationSection section)
        {
            var config = ConfigurationConverter.Convert(section);
            MessageManager = new MessageManager(config);
            Configuration = config;
        }

        public static IMessenger GetMessenger()
        {
            return new Messenger(Configuration,MessageManager);
        }
    }
}