using System;

using Core;
using Core.Managers;

using Models;

using Infrastructure.Commands;

using NLog;

using Newtonsoft.Json;


namespace ConsoleInvoker
{
    class Program
    {

        static void Main(string[] args)
        {
            InvokerCore core = new InvokerCore();
            var manager = core.Services.GetInstance<ICommandManager>();
            manager.RegistryCommandUseAttribute<QuitCommand>();
            var command = core.Services.GetInstance<ICommand>("Quit");
            var logger = core.Services.GetInstance<ILogger>();
            logger.Fatal("Fatal");
            Console.WriteLine(command.Description);
            Console.ReadKey();
        }
    }
}