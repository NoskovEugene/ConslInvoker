using System.Reflection;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System;
using System.Text;

using Core;

using SharedModels;

using Infrastructure.Commands;
using Core.TypeConverter;
using Core.CoreSettings;

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
}