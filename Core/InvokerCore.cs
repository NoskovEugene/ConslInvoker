using System;

using StructureMap;

using NLog;
using NLog.Extensions;
using NLog.Extensions.Logging;

using Core.Buses;
using Core.Managers;
using Core.Analyzers;
using Models;
using Infrastructure;
using Infrastructure.Commands;

using Microsoft.Extensions.Configuration;

using UI.MessengerUI;

namespace Core
{
    public class InvokerCore
    {
        public IConfiguration Configuration { get; }

        public IMessenger Messenger { get; }

        public Container Services { get; }

        public ICommandManager CommandManager { get; }

        public IAnalyzerManager Analyzermanager { get; }

        public InvokerCore()
        {
            Configuration = CreateConfiguration();
            InitLoggers();
            Services = new Container();
            Services.Configure(x =>
            {
                
                x.For<Container>().Singleton().Add(Services);
                x.For<ICommandManager>().Singleton().Use<CommandManager>();
                x.For<IAnalyzerManager>().Singleton().Use<AnalyzerManager>();
                x.For<IMessenger>().Add(MessengerManager.GetMessenger());
                x.For<ICommandBus>().Use<CommandBus>();
            });
            CommandManager = Services.GetInstance<ICommandManager>();
            Analyzermanager = Services.GetInstance<IAnalyzerManager>();
            Analyzermanager.AddAnalyzer<Analyzer>();
        }

        protected void InitLoggers()
        {
            LogManager.Configuration = new NLogLoggingConfiguration(Configuration.GetSection("NLog"));
            MessengerManager.SetConfiguration(Configuration.GetSection("Messenger"));
        }

        protected IConfiguration CreateConfiguration()
        {
            var config = new ConfigurationBuilder();
            config.AddJsonFile("appsettings.json");
            return config.Build();
        }

        public void StartListen()
        {
            var mainBus = Services.GetInstance<ICommandBus>();
            while(true)
            {
                Console.Write(">_ ");
                var line = Console.ReadLine();
                mainBus.Execute(line);
            }
        }
    }
}