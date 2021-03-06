using Models;
using Core.Managers;
using UI.MessengerUI;

namespace Core.Buses
{
    public class CommandBus : ICommandBus
    {
        protected ICommandManager CommandManager { get; }

        protected IAnalyzerManager AnalyzerManager { get; }

        protected IMessenger Messenger { get; }

        public CommandBus(ICommandManager commandManager, IAnalyzerManager analyzerManager, IMessenger messenger)
        {
            CommandManager = commandManager;
            AnalyzerManager = analyzerManager;
            Messenger = messenger;
        }


        public void Execute(string line)
        {
            Messenger.Trace($"Input string {line}");
            var package = AnalyzerManager.Analyze(line);
            Messenger.Trace("Trying find command");
            if(CommandManager.TryFoundCommand(package.Command,out var command))
            {
                command.Execute(package);
            }
            else
            {
                Messenger.Fatal("Command not found");
            }
        }
    }
}