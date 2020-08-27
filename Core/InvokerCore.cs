using System;

using StructureMap;

using NLog;

using Core.Managers;
using Models;
using Infrastructure;
using Infrastructure.Commands;


namespace Core
{
    public class InvokerCore
    {
        public ILogger Logger { get; }

        public Container Services { get; }

        public ICommandManager CommandManager { get; }

        public IAnalyzerManager Analyzermanager { get; }

        public InvokerCore()
        {
            Logger = LogManager.GetLogger("console");
            Services = new Container();
            Services.Configure(x =>
            {
                x.For<Container>().Singleton().Add(Services);
                x.For<ILogger>().Singleton().Add(Logger);
                x.For<ICommandManager>().Singleton().Use<CommandManager>();
                x.For<IAnalyzerManager>().Singleton().Use<AnalyzerManager>();
            });
            CommandManager = Services.GetInstance<ICommandManager>();
            Analyzermanager = Services.GetInstance<IAnalyzerManager>();
        }
    }
}