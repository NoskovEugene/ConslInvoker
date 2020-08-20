using Models;
using System;
using System.Reflection;
using Infrastructure.Attributes;
namespace Infrastructure.Commands
{
    [CommandInfo("Quit")]
    public class QuitCommand : ICommand
    {
        public string Command => "quit";

        public string Description => "Command for quit from application";

        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}