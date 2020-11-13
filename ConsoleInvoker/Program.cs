using Microsoft.VisualBasic.CompilerServices;
using System;

using Core;

using Infrastructure.Commands;

using Shared.Models;

using Routing;
using Routing.Models;
using System.Reflection;
using Shared.Attributes;
using StructureMap;

namespace ConsoleInvoker
{
    class Program
    {
        static void Main(string[] args)
        {
            var core = new InvokerCore();
            core.Services.Configure(x=> x.For<Router>().Use<Router>());
            core.CommandManager.RegistryCommandUseAttribute<QuitCommand>();
            core.CommandManager.RegistryCommandUseAttribute<MessengerTestCommand>();
            core.CommandManager.RegistryCommandUseAttribute<RequesterTestCommand>();
            core.CommandManager.RegistryCommandUseAttribute<SetToStorageItemCommand>();
            core.CommandManager.RegistryCommandUseAttribute<GetFromStorageCommand>();

            var router = core.Services.GetInstance<Router>();
            router.AddApi<ToDoApi>();

            Console.ReadKey();
        }
    }

    [Utility(UtilityName = "todo")]
    public class ToDoApi
    {

        [Rout(CommandName = "add", Parameters = "[Start datetime] [ToDoType]")]
        public void AddToDo(string startDateTime, int toDoType)
        {

        }

        [Rout(CommandName = "add", Parameters = "[Start datetime] [ToDoType] {[Sunday] [Monday] [Tuesday] [Wednesday] [Thursday] [Friday] [Saturday]}")]
        public void AddToDo(string startDateTime, int toDoType, params int[] dayOfWeek)
        {

        }
    }
}