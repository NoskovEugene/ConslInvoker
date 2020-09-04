using System;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;
using UI.MessengerUI;

namespace UI.Request
{
    public class Requester : IRequester
    {

        protected IMessenger Messenger;

        public Requester(IMessenger messenger)
        {
            Messenger = messenger;
        }

        public string Request(string message)
        {
            Messenger.Info(message);
            Messenger.Info("$ ", false);
            return Console.ReadLine();
        }

        public T Request<T>(string message)
        {
            while (true)
            {
                Messenger.Info(message);
                Messenger.Info("$ ", false);
                var line = Console.ReadLine();
                try
                {
                    var obj = Convert.ChangeType(line, typeof(T));
                    return (T)obj;
                }
                catch(Exception ex)
                {
                    Messenger.Error("Error while convert types");
                    Messenger.Trace(ex.Message);
                }
            }
        }

    }
}