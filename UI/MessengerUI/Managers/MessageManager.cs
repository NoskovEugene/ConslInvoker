using System;
using System.Collections.Generic;
using UI.MessengerUI.InternalModels;
using UI.MessengerUI.Configurations;
using UI.MessengerUI.Enums;
using UI.MessengerUI.Processors;
namespace UI.MessengerUI.Managers
{


    public sealed class MessageManager : IMessageManager
    {
        Queue<MessageEvent> MainQueue { get; }

        Configuration Configuration { get; }

        Dictionary<MessageType, Profile> Dict { get; }
        public MessageManager(Configuration configuration)
        {
            MainQueue = new Queue<MessageEvent>();
            this.Configuration = configuration;
            Dict = new Dictionary<MessageType, Profile>();
            Dict.Add(MessageType.Trace, configuration.TraceProfile);
            Dict.Add(MessageType.Fatal, configuration.FatalProfile);
            Dict.Add(MessageType.Error, configuration.ErrorProfile);
            Dict.Add(MessageType.Warn, configuration.WarnProfile);
            Dict.Add(MessageType.Info, configuration.InfoProfile);
        }

        public void Add(MessageEvent message)
        {
            message.Message = StringProcessor.Expand(Configuration.Pattern, message.Message, message.MessageType);
            MainQueue.Enqueue(message);
            ShowMessage();
        }

        public void Add(string message, MessageType messageType)
        {
            Add(new MessageEvent(message,messageType));
        }        

        void ShowMessage()
        {
            var message = MainQueue.Peek();
            MainQueue.Dequeue();
            if (message.MessageType >= Configuration.MinLevel)
            {
                var foregroundGlass = Console.ForegroundColor;
                var backgroundGlass = Console.BackgroundColor;
                var profile = Dict[message.MessageType];
                Console.ForegroundColor = profile.ForegroundColor;
                Console.BackgroundColor = profile.BackgroundColor;
                Console.WriteLine(message.Message);
                Console.ForegroundColor = foregroundGlass;
                Console.BackgroundColor = backgroundGlass;
            }
        }
    }
}