using System;
using Models;
using Infrastructure;
using Infrastructure.Commands;
using StructureMap;
using Core.Managers;

namespace Core
{
    public class InvokerCore
    {

        public Container Services {get;}

        public CommandManager CommandManager{get;private set;}

        public InvokerCore()
        {
            Services = new Container();
            CommandManager = new CommandManager(Services);
            Services.Configure(x=>{
                x.For<ICommandManager>().Singleton().Add<CommandManager>(CommandManager);
            });
        }


    }
}