
using System;
using Core;

using Infrastructure.Commands;
using UI.MessengerUI;
using UI.Request;

namespace ConsoleInvoker
{
    class Program
    {
        static void Main(string[] args)
        {
            var core = new InvokerCore();
            core.CommandManager.RegistryCommandUseAttribute<QuitCommand>();
            core.CommandManager.RegistryCommandUseAttribute<MessengerTestCommand>();
            var messenger = core.Services.GetInstance<IMessenger>();    
            var requester = core.Services.GetInstance<IRequester>();
            var country = requester.Request("Where are you from?");
            var age = requester.Request<int>("how old are you?");
            messenger.Info($"{nameof(country)}, value = {country}, type = {country.GetType()}");
            messenger.Info($"{nameof(age)}, value = {age}, type = {age.GetType()}");
            Console.ReadKey();
        }
    }
}