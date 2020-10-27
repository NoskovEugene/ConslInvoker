using SharedModels;
using UI.MessengerUI;
using Infrastructure.Attributes;

namespace Infrastructure.Commands
{
    [CommandInfo("testmessenger")]
    public class MessengerTestCommand : ICommand
    {
        protected IMessenger Messenger { get; }

        public MessengerTestCommand(IMessenger messenger)
        {
            this.Messenger = messenger;
        }

        public string Command => "testmessenger";

        public string Description => "For testing messenger";

        public void Execute(Package package)
        {
            Messenger.Trace("This is trace");
            Messenger.Info("This is info message");
            Messenger.Info("This is info\nWith new line");
            Messenger.Warn("This is warn message");
            Messenger.Error("This is error");
            Messenger.Fatal("This is fatal error");
        }
    }
}