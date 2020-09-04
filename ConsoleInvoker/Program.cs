using System;
using System.Text;

using Core;

using Infrastructure.Commands;
using UI.MessengerUI;
using UI.Request;
using System.Runtime.InteropServices;
using System.Collections.Generic;

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
            core.StartListen();
            Console.ReadKey();
        }
    }

    public class Some
    {
        public string str { get; set; }
        public Some(string str)
        {
            this.str = str;
        }
    }

}