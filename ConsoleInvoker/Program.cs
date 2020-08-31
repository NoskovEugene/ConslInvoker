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
            var color = Console.ReadLine();
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor),color);
            Console.WriteLine(color);
            Console.ReadKey();
        }
    }
}