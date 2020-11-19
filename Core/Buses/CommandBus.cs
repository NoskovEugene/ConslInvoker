using Shared.Models;
using Core.Managers;
using UI.MessengerUI;

namespace Core.Buses
{
    public class CommandBus : ICommandBus
    {
        protected ICommandManager CommandManager { get; }

        protected IMessenger Messenger { get; }

        public CommandBus(ICommandManager commandManager,
                          IMessenger messenger)
        {
            CommandManager = commandManager;
            Messenger = messenger;
        }


        public void Execute(string line)
        {
            Messenger.Trace($"Input string '{line}'");
            if(package.ExistException) {Messenger.Trace("ExistException now true. Exit."); return;}
            Messenger.Trace($"Trying find command {package.Command}");
            if(CommandManager.TryFoundCommand(package.Command,out var command))
            {
                Messenger.Trace($"Success. Finded '{command.GetType().Name}'");
                command.Execute(package);
            }
            else
            {
                Messenger.Fatal("Command not found");
            }
        }
    }
}
