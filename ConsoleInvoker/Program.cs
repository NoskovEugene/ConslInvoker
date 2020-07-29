using System;
using Models;
using Infrastructure;
using Infrastructure.Commands;
using Core;
using StructureMap;
namespace ConsoleInvoker
{
    class Program
    {
        static void Main(string[] args)
        {
            var core = new InvokerCore();
            core.Services.Configure(configure=>
            {
                configure.For<ICommand>().Use<QuitCommand>().Named("quit");
            });
            var command = core.Services.TryGetInstance<ICommand>("quit");
            Console.WriteLine(command.Command);
            Console.ReadKey();
            
        }
    }
}
