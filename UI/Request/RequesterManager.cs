using Microsoft.Extensions.Configuration;
using UI.MessengerUI;
using UI.MessengerUI.Configurations;

namespace UI.Request
{
    public static class RequesterManager
    {
        static Configuration Configuration;

        public static void SetConfiguration(IConfiguration configuration)
        {
            Configuration = MessengerManager.CreateConfiguration(configuration.GetSection("Messenger"));
            Configuration.Pattern = "${message}";
        }

        public static IRequester GetRequester()
        {
            return new Requester(MessengerManager.GetMessenger(Configuration));
        }
    }
}