using System;

using UI.MessengerUI.Configurations;
using UI.MessengerUI.Processors;
using UI.MessengerUI.Enums;
using UI.MessengerUI.Managers;

namespace UI.MessengerUI
{
    public class Messenger : IMessenger
    {
        protected Configuration Configuration { get; set; }

        protected IMessageManager MessageManager { get; set; }

        public Messenger(Configuration config, IMessageManager messageManager)
        {
            this.Configuration = config;
            this.MessageManager = messageManager;
        }

        public void Trace(string message)
        {
            MessageManager.Add(message,MessageType.Trace);
        }

        public void Info(string message)
        {
            MessageManager.Add(message,MessageType.Info);
        }

        public void Warn(string message)
        {
            MessageManager.Add(message,MessageType.Warn);
        }

        public void Error(string message)
        {
            MessageManager.Add(message,MessageType.Error);
        }

        public void Fatal(string message)
        {
            MessageManager.Add(message,MessageType.Fatal);
        }
    }
}