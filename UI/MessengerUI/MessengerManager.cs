using Microsoft.Extensions.Configuration;
using UI.MessengerUI.Configurations;


namespace UI.MessengerUI
{
    public static class MessengerManager
    {
        private static Configuration Configuration;

        public static void SetConfiguration(Configuration configuration)
        {
            Configuration = configuration;
        }

        public static void SetConfiguration(IConfigurationSection section)
        {
            var config = ConfigurationConverter.Convert(section);
            Configuration = config;
        }

        public static IMessenger GetMessenger()
        {
            return new Messenger(Configuration);
        }
    }
}