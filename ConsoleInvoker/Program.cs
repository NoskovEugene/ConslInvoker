using System;
using System.Text;

using Core;
using Core.Storage.Models;

using Infrastructure.Commands;
using UI.MessengerUI;
using UI.Request;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Core.Storage;
using AutoMapper;

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
            Console.ReadKey();
        }
    }


    public class SomeStructure
    {
        public int A { get; set; }

        public int B { get; set; }
    }
}