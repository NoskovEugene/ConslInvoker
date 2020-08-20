using System;
using Models;
using Infrastructure;
using Infrastructure.Commands;
using StructureMap;
using System.Threading;
using System.Diagnostics;
using Core;
using Core.Managers;

namespace ConsoleInvoker
{
    class Program
    {

        static void Main(string[] args)
        {
            InvokerCore core = new InvokerCore();
            var manager = core.Services.GetInstance<ICommandManager>();
            manager.RegistryNewCommandUseAttribute<QuitCommand>();
            Console.ReadKey();
        }


    }
}
