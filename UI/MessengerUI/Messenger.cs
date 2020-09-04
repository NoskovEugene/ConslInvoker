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

        public void Trace(string message, bool createNewLine = true)
        {
            MessageManager.Add(message, MessageType.Trace, createNewLine);
        }

        public void Info(string message, bool createNewLine = true)
        {
            MessageManager.Add(message, MessageType.Info, createNewLine);
        }

        public void Warn(string message, bool createNewLine = true)
        {
            MessageManager.Add(message, MessageType.Warn, createNewLine);
        }

        public void Error(string message, bool createNewLine = true)
        {
            MessageManager.Add(message, MessageType.Error, createNewLine);
        }

        public void Fatal(string message, bool createNewLine = true)
        {
            MessageManager.Add(message, MessageType.Fatal, createNewLine);
        }
    }
}