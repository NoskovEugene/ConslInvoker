using Models;
using Infrastructure.Attributes;
using Infrastructure.Extensions;
using UI.MessengerUI;
using UI.Request;

namespace Infrastructure.Commands
{

    [CommandInfo("settostorage")]
    public class SetToStorageItemCommand : ICommand
    {
        public string Command => "settostorage";

        public string Description => "For set to app storage";

        protected IAppStorage AppStorage { get; }

        protected ITypeMapper TypeMapper { get; }

        protected IRequester Requester { get; }

        protected IMessenger Messenger { get; }

        public SetToStorageItemCommand(IAppStorage appStorage,
                                       ITypeMapper typeMapper,
                                       IRequester requester,
                                       IMessenger messenger)
        {
            this.AppStorage = appStorage;
            this.TypeMapper = typeMapper;
            this.Requester = requester;
            this.Messenger = messenger; 
        }

        public void Execute(Package package)
        {
            package = ParseParam(package);
            var key = (string)package.ParsedParameter["key"];
            var value = (string)package.ParsedParameter["value"];
            if(AppStorage.Find(key) != null)
            {
                Messenger.Error($"Value with key : {key} already exist");
            }

            if(Requester.YNQuestionKey($"Insert value '{value}' with key '{key}' in storage"))
            {
                AppStorage.Insert<string>(key,value);
                Messenger.Info("Value added");
            }
        }

        private Package ParseParam(Package package)
        {
            var arr = package.Parameter.Split(System.StringSplitOptions.RemoveEmptyEntries, "=");
            var key = arr.Length >= 1 ? arr[0] : Requester.Request<string>("Enter key for storage");
            var value = arr.Length >= 2 ? arr[1] : Requester.Request<string>("Enter value for storage");
            package.ParsedParameter.Add("key", key);
            package.ParsedParameter.Add("value", value);
            package.Parameter = "";
            return package;
        }
    }
}