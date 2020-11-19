using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Linq;


using Shared.Models.Packages;
using UI.MessengerUI;

namespace Core.Managers
{
    public class PackageCreator
    {

        public Dictionary<string, Func<string, Action<string>, string>> RuleSet { get; set; }

        protected IMessenger Messenger { get; set; }

        public PackageCreator(IMessenger messenger)
        {
            Messenger = messenger;
        }





        public Package<UserPackage> CreateUserPackage(string line)
        {
            var array = line.Split(' ');
            var payLoad = new UserPackage();
            var command = array.First();
            line = line.Replace(command, string.Empty);
            if (!command.Contains(":"))
            {
                Messenger.Error("Utility cannot be empty");
            }
            var utility = command.Split(':')[0];
            command = command.Replace(utility, string.Empty);
            payLoad.Utility = utility;
            payLoad.Command = command;
            array = array.Where(x => x != array.First()).ToArray();
            payLoad.Parameters = array;
        }


    }
}
