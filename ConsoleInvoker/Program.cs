using System;
using System.Threading;
using System.Diagnostics;

using StructureMap;

using Core;
using Core.Managers;

using Models;

using Infrastructure.Commands;

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
            Console.WriteLine(command.Description);
            Console.ReadKey();
        }
    }
}
