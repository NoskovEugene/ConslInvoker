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

        public static void SetConfiguration(IConfiguration configuration)
        {
            var config = ConfigurationConverter.Convert(configuration.GetSection("Messenger"));
            MessageManager = new MessageManager(config);
            Configuration = config;
        }

        public static Configuration CreateConfiguration(IConfigurationSection section)
        {
            var config = ConfigurationConverter.Convert(section);
            return config;
        }

        public static IMessenger GetMessenger()
        {
            return new Messenger(Configuration, MessageManager);
        }

        public static IMessenger GetMessenger(Configuration configuration)
        {
            return new Messenger(configuration, new MessageManager(configuration));
        }
    }
}