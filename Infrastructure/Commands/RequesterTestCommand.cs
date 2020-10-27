using System.Text;

using UI.Request;
using UI.MessengerUI;
using SharedModels;
using Infrastructure.Attributes;

namespace Infrastructure.Commands
{
    [CommandInfo("testrequester")]
    public class RequesterTestCommand : ICommand
    {
        protected IRequester Requester { get; }

        protected IMessenger Messenger { get; }

        public string Command => "testrequester";

        public string Description => "For test requester";

        public RequesterTestCommand(IRequester requester, IMessenger messenger)
        {
            this.Requester = requester;
            this.Messenger = messenger;
        }

        public void Execute(Package package)
        {
            var strItem = Requester.Request("Test string request");
            Messenger.Info(strItem);
            var intItem = Requester.Request<int>("Test int item");
            Messenger.Info(intItem.ToString());
            var item = Requester.Request<int, Encoding>("type encoding page (1200)", x=> Encoding.GetEncoding(x));
            Messenger.Info($"Type is {item.GetType()}");
            var boolItem = Requester.YNQuestionKey("Delete?");
            Messenger.Info(boolItem.ToString());

        }
    }
}