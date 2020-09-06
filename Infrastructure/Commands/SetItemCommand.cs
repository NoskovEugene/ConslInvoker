using Infrastructure.Attributes;
using Infrastructure.Extensions;
using UI.MessengerUI;
using UI.Request;
using Models;
using System;

namespace Infrastructure.Commands
{

    [CommandInfo("set")]
    public class SetItemCommand : ICommand
    {
        public string Command => "setitem";

        public string Description => "for set something to storage";

        protected IMessenger Messenger { get; }

        protected IRequester Requester { get; }

        protected IAppStorage AppStorage { get; }

        public SetItemCommand(IMessenger messenger,
                              IRequester requester,
                              IAppStorage appStorage)
        {
            this.Messenger = messenger;
            this.Requester = requester;
            this.AppStorage = appStorage;
        }

        public void Execute(Package package)
        {

        }

        private bool AnalyzePackage(Package pack)
        {
            if (pack.Parameter != "")
            {
                var array = pack.Parameter.Split(StringSplitOptions.RemoveEmptyEntries, " ");

            }

            return false;
        }
    }
}