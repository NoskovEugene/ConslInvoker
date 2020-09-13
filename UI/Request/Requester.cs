using System;
using System.Linq;
using System.Collections.Generic;
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
                catch (Exception ex)
                {
                    Messenger.Error("Error while convert types");
                    Messenger.Trace(ex.Message);
                }
            }
        }

        public TOut Request<T, TOut>(string message, Func<T, TOut> customCast)
        {
            var tItem = Request<T>(message);
            while (true)
            {
                try
                {
                    var outItem = customCast(tItem);
                    return outItem;
                }
                catch (Exception ex)
                {
                    Messenger.Error("Error while convert type");
                    Messenger.Trace(ex.Message);
                }
            }
        }

        public bool YNQuestionKey(string message)
        {
            Messenger.Info(message);
            Messenger.Info("[Y/N] ", false);
            var keyLine = Console.ReadLine();
            if (keyLine == "y" || keyLine == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public T Chooser<T>(IList<T> root)
        {
            return Chooser(root, x => x.ToString());
        }

        public T Chooser<T>(IList<T> root, Func<T, string> customToString)
        {
            var pattern = root.Count() < 10 ? "{0,1}){1}" : "{0,2}){1}";
            for (var i = 0; i < root.Count(); i++)
            {
                var line = string.Format(pattern, i, customToString(root[i]));
                Messenger.Info(line);
            }

            while (true)
            {
                var index = Request<int>("Select the one you need and write the index");
                if (index >= 0 && index < root.Count)
                {
                    return root[index];
                }
                else
                {
                    Messenger.Fatal("Index was out of range.");
                }
            }
        }
    }
}