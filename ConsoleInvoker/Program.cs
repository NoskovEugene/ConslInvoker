using System.Runtime.InteropServices;
using System.Diagnostics;
using System;

using Core;
using Core.Managers;

using Models;

using Infrastructure.Commands;

using NLog;

using Newtonsoft.Json;
using System.ComponentModel;
using System.Threading.Tasks;
using UI.MessengerUI;

namespace ConsoleInvoker
{
    class Program
    {

        static void Main(string[] args)
        {
            var core = new InvokerCore();
            var messenger = core.Services.GetInstance<IMessenger>();
            messenger.Info("Info");
            messenger.Warn("Warn");
            messenger.Error("Error");
            messenger.Fatal("Fatal");
            Console.ReadKey();
        }
    }
}