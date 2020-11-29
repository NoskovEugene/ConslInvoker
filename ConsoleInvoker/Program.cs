using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Reflection;

using Core;
using Core.Buses;

using Routing;
using Shared.Attributes;
using System.Collections.Generic;
using UI.MessengerUI;
using Shared.Models.Router;
using Shared.Models.Packages;
using Core.Managers;
using Core.Extensions.StructureMapExtensions;

namespace ConsoleInvoker
{
    class Program
    {
        static void Main(string[] args)
        {
			var core = new InvokerCore();
			core.Services.ConfigureOption<AppConfig>(core.Configuration.GetSection("AppConfig"));
			var option = core.Services.GetInstance<IOption<AppConfig>>();
            Console.ReadKey();
        }
    }



	public class AppConfig
	{
		public string A {get;set;}

		public string ConnectionString {get;set;}
	}






    [Utility(UtilityName = "todo")]
    [Parser(typeof(Program))]
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
            Messenger.Info(startDateTime);
            Messenger.Info(toDoType.ToString());
        }

        [Rout(CommandName = "add", Parameters = "[Start datetime] [ToDoType] {[Sunday] [Monday] [Tuesday] [Wednesday] [Thursday] [Friday] [Saturday]}")]
        public void AddToDo(string startDateTime, int toDoType, params int[] dayOfWeek)
        {
            Messenger.Info(startDateTime);
            Messenger.Info(toDoType.ToString());
            foreach (var item in dayOfWeek)
            {
                Messenger.Info(item.ToString());
            }
        }
    }

    public class Parser : IParser
    {
        public Dictionary<string, object> Parameters { get; private set; }
        public bool Success { get; set; }
        public string ExceptionMessage { get; set; }
        public Exception Exception { get; set; }

        public Dictionary<string, Func<string, object>> rules = new Dictionary<string, Func<string, object>>();

        public Parser()
        {
            rules.Add("Start datetime", x => x);
            rules.Add("ToDoType", x => int.TryParse(x, out var res) ? res : 0);
            rules.Add("dayOfWeek", x => int.TryParse(x, out var res) ? res : 1);
            Parameters = new Dictionary<string, object>();
        }

        public void Parse(UserPackage package, NeedRout rout)
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
