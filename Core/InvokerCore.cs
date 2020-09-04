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
        /// <summary>
        /// Конфигурация приложения
        /// </summary>
        /// <value></value>
        public IConfiguration Configuration { get; }


        /// <summary>
        /// Контейнер приложения
        /// </summary>
        /// <value></value>
        public Container Services { get; }

        /// <summary>
        /// Менеджер команд
        /// </summary>
        /// <value></value>
        public ICommandManager CommandManager { get; }

        

        public InvokerCore()
        {
            Configuration = CreateConfiguration();
            InitLoggers();
            Services = new Container();
            Services.Configure(x =>
            {
                x.For<ILogger>().Add(LogManager.GetLogger("coloredConsole"));
                x.For<Container>().Singleton().Add(Services);
                x.For<ICommandManager>().Singleton().Use<CommandManager>();
                x.For<IAnalyzerManager>().Singleton().Use<AnalyzerManager>();
                x.For<IMessenger>().Add(MessengerManager.GetMessenger());
                x.For<ICommandBus>().Use<CommandBus>();
            });
            CommandManager = Services.GetInstance<ICommandManager>();
            var analyzermanager = Services.GetInstance<IAnalyzerManager>();
            analyzermanager.AddAnalyzer<Analyzer>();
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

        /// <summary>
        /// Переводит ядро в режим ожидания
        /// </summary>
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