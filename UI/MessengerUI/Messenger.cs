using System;

using UI.MessengerUI.Configurations;
using UI.MessengerUI.Processors;
using UI.MessengerUI.Enums;

namespace UI.MessengerUI
{
    public class Messenger : IMessenger
    {
        protected Configuration Configuration { get; set; }

        public Messenger(Configuration config)
        {
            this.Configuration = config;
        }


        public void Info(string message)
        {
            message = ConvertToPattern(message, MessengerType.Info);
            ShowMessage(Configuration.InfoProfile.ForegroundColor,
                        Configuration.InfoProfile.BackgroundColor,
                        message);
        }

        public void Warn(string message)
        {
            message = ConvertToPattern(message, MessengerType.Warn);
            ShowMessage(Configuration.WarnProfile.ForegroundColor,
                        Configuration.WarnProfile.BackgroundColor,
                        message);
        }

        public void Error(string message)
        {
            message = ConvertToPattern(message, MessengerType.Error);
            ShowMessage(Configuration.ErrorProfile.ForegroundColor,
                        Configuration.ErrorProfile.BackgroundColor,
                        message);
        }

        public void Fatal(string message)
        {
            message = ConvertToPattern(message, MessengerType.Fatal);
            ShowMessage(Configuration.FatalProfile.ForegroundColor,
                        Configuration.FatalProfile.BackgroundColor,
                        message);
        }

        private string ConvertToPattern(string message, MessengerType type)
        {
            return StringProcessor.Expand(Configuration.Pattern, message, type);
        }

        private void ShowMessage(ConsoleColor foreground, ConsoleColor background, string message)
        {
            var foregroundGlass = Console.ForegroundColor;
            var backgroundGlass = Console.BackgroundColor;
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.WriteLine(message);
            Console.ForegroundColor = foregroundGlass;
            Console.BackgroundColor = backgroundGlass;
        }
    }
}