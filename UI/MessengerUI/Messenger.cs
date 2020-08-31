using System;

using UI.MessengerUI.Configurations;

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
            ShowMessage(Configuration.InfoProfile.ForegroundColor,
                        Configuration.InfoProfile.BackgroundColor,
                        message);
        }

        public void Warn(string message)
        {
            ShowMessage(Configuration.WarnProfile.ForegroundColor,
                        Configuration.WarnProfile.BackgroundColor,
                        message);
        }

        public void Error(string message)
        {
            ShowMessage(Configuration.ErrorProfile.ForegroundColor,
                        Configuration.ErrorProfile.BackgroundColor,
                        message);
        }

        public void Fatal (string message)
        {
            ShowMessage(Configuration.FatalProfile.ForegroundColor,
                        Configuration.FatalProfile.BackgroundColor,
                        message);
        }


        private void ShowMessage(ConsoleColor foreground, ConsoleColor background,string message)
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