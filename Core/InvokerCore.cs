using System;

using StructureMap;

using NLog;
using NLog.Extensions;
using NLog.Extensions.Logging;

using Core.Managers;
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
            });
            CommandManager = Services.GetInstance<ICommandManager>();
            Analyzermanager = Services.GetInstance<IAnalyzerManager>();
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

        

    }
}