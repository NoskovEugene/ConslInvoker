using Models;
using Infrastructure.Extensions;
using Infrastructure.Attributes;
using UI.MessengerUI;
using UI.Request;
namespace Infrastructure.Commands
{
    [CommandInfo("getfromstorage")]
    public class GetFromStorageCommand : ICommand
    {
        public string Command => "getfromstorage";

        public string Description => "Get value from storage";

        protected IRequester Requester { get; }

        protected IMessenger Messenger { get; }

        protected IAppStorage AppStorage { get; }

        public GetFromStorageCommand(IRequester requester,
                                     IMessenger messenger,
                                     IAppStorage appStorage)
        {
            this.Requester = requester;
            this.Messenger = messenger;
            this.AppStorage = appStorage;
        }

        public void Execute(Package package)
        {
            package = Parse(package);
            var key = (string)package.ParsedParameter["key"];
            var value = AppStorage.Find(key);
            if(value == null){
                Messenger.Error($"Value by {key} not found");
                return;
            }
            Messenger.Info($"Value from storage by {key} is {value.ToString()}");
        }

        public Package Parse(Package input)
        {
            var key = input.Parameter;
            input.ParsedParameter .Add("key", key);
            input.Parameter = "";
            return input;
        }



    }
}