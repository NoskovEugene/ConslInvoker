using Models;
using System;
using System.Reflection;
namespace Infrastructure.Commands
{
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