using System;

using Core;

using Infrastructure.Commands;

using Shared.Models;

namespace ConsoleInvoker
{
    class Program
    {
        static void Main(string[] args)
        {
            var core = new InvokerCore();
            core.CommandManager.RegistryCommandUseAttribute<QuitCommand>();
            core.CommandManager.RegistryCommandUseAttribute<MessengerTestCommand>();
            core.CommandManager.RegistryCommandUseAttribute<RequesterTestCommand>();
            core.CommandManager.RegistryCommandUseAttribute<SetToStorageItemCommand>();
            core.CommandManager.RegistryCommandUseAttribute<GetFromStorageCommand>();
            core.StartListen();
            Console.ReadKey();
        }
    }
}