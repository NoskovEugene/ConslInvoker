using System.Threading;
using SharedModels;
using System;
using System.Reflection;
using Infrastructure.Attributes;
using UI.MessengerUI;
namespace Infrastructure.Commands
{
    [CommandInfo("quit")]
    public class QuitCommand : ICommand
    {
        protected IMessenger Messenger { get; }

        public QuitCommand(IMessenger messenger)
        {
            this.Messenger = messenger;
        }

        public string Command => "quit";

        public string Description => "Command for quit from application";

        public void Execute(Package package)
        {
            for(int i = 5; i>= 0;i--)
            {
                Messenger.Info($"Program will be closed in {i} second...");
                Thread.Sleep(1000);
            }
            Environment.Exit(0);
        }
    }
}