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


        public Container Services { get; }

        public ICommandManager CommandManager { get; }

        public IAnalyzerManager Analyzermanager { get; }

        public InvokerCore()
        {
            Services = new Container();
            Services.Configure(x =>
            {
                x.For<Container>().Singleton().Add(Services);
                x.For<ICommandManager>().Singleton().Use<CommandManager>();
                x.For<IAnalyzerManager>().Singleton().Use<AnalyzerManager>();
            });
            CommandManager = Services.GetInstance<ICommandManager>();
            Analyzermanager = Services.GetInstance<IAnalyzerManager>();
        }
    }
}