using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Linq;


using Shared.Models.Packages;
using UI.MessengerUI;
using Shared.Extensions;

namespace Core.Managers
{


    public class PackageCreator : IPackageCreator
    {

        public Dictionary<string, Func<string, Action<string>, string>> RuleSet { get; set; }

        protected IMessenger Messenger { get; set; }

        public PackageCreator(IMessenger messenger)
        {
            Messenger = messenger;
        }

        public Package Parse(Package package)
        {
            package = package.Swap();

            if (package.TryGetPayload<UserPackage>(out var output))
            {
                var line = output.InputLine;
                var arr = line.Split(' ');
                var command = arr.First();
                if (!command.Contains(":"))
                {
                    return Bad(package, "Входящая строка не имеет утилиты");
                }
                var commandArr = command.Split(':');
                output.Util = commandArr.First();
                output.Command = commandArr.Last();
                arr = arr.Where(x => x != command).ToArray();
                output.UnparserParams = string.Join(" ", arr).Trim();
                output.SplitedParams = arr;
                return output;
            }
            else
            {
                return Bad(package, "Пакет имеет неверный тип");
            }
        }

        public Package Bad(Package package, string message)
        {
            var messagePack = (MessagePackage)package;
            messagePack.Message = message;
            return messagePack;
        }


    }
}
