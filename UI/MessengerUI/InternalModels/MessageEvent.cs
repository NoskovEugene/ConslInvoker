using System;
using UI.MessengerUI.Configurations;
using UI.MessengerUI.Enums;

namespace UI.MessengerUI.InternalModels
{
    public class MessageEvent
    {
        public string Message { get; set; }

        public MessageType MessageType { get; set; }

        public MessageEvent(string message, MessageType messageType)
        {
            this.Message = message;
            this.MessageType = messageType;
        }
    }
}