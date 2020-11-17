using Microsoft.VisualBasic.CompilerServices;
using System;

using Core;

using Infrastructure.Commands;

using Shared.Models;

using Routing;
using System.Reflection;
using Shared.Attributes;
using StructureMap;
using System.Collections.Generic;
using UI.MessengerUI;

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

            var router = core.Services.GetInstance<Router>();
            router.AddApi<ToDoApi>();
            var pckg = new Package() { Utility = "todo", Command = "add", Parameter = "hello world" };
            pckg.SplitedParams = pckg.Parameter.Split(' ');
            var rout = router.GetRout(pckg);
            if (rout.Utility.ParserExists)
            {
                IParser parser = (IParser)rout.Utility.ParserInstanse;
                parser.Parse(pckg, rout);
                pckg.ParsedParameter = parser.Parameters;
            }
            Console.ReadKey();
        }
    }

    [Utility(UtilityName = "todo")]
    [Parser(typeof(Parser))]
    public class ToDoApi
    {

        IMessenger Messenger { get; set; }

        public ToDoApi(IMessenger messenger)
        {
            Messenger = messenger;
        }

        [Rout(CommandName = "add", Parameters = "[Start datetime] [ToDoType]")]
        public void AddToDo(string startDateTime, int toDoType)
        {
            Messenger.Info("Hello world");
        }

        [Rout(CommandName = "add", Parameters = "[Start datetime] [ToDoType] {[Sunday] [Monday] [Tuesday] [Wednesday] [Thursday] [Friday] [Saturday]}")]
        public void AddToDo(string startDateTime, int toDoType, params int[] dayOfWeek)
        {

        }
    }

    public class Parser : IParser
    {
        public Dictionary<string, object> Parameters { get; private set; }
        public bool Success { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ExceptionMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Exception Exception { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Dictionary<string, Func<string, object>> rules = new Dictionary<string, Func<string, object>>();

        public Parser()
        {
            rules.Add("Start datetime", x => x);
            rules.Add("ToDoType", x => int.TryParse(x, out var res) ? res : 0);
            rules.Add("dayOfWeek", x => int.TryParse(x, out var res) ? res : 1);
            Parameters = new Dictionary<string, object>();
        }

        public void Parse(Package package, NeedRout rout)
        {
            var parameters = package.SplitedParams;
            for (int i = 0; i < parameters.Length; i++)
            {
                if (rules.ContainsKey(rout.Rout.Parameters[i].Name))
                {
                    Parameters.Add(rout.Rout.Parameters[i].Name, rules[rout.Rout.Parameters[i].Name](package.SplitedParams[i]));
                }
            }
        }
    }
}