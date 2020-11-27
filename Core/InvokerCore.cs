using System;

using StructureMap;

using NLog;
using NLog.Extensions.Logging;

using Core.Buses;
using Core.Managers;
using Core.Storage;

using UI.MessengerUI;
using UI.Request;

using Shared.Models;

using Microsoft.Extensions.Configuration;

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
                x.For<ITypeMapperFactory>().Singleton().Use<TypeMapperFactory>();
                x.For<IRequester>().Use(x => RequesterManager.GetRequester());
                x.For<IMessenger>().Use(x => MessengerManager.GetMessenger());
                x.For<ITypeMapper>().Use(x => x.GetInstance<ITypeMapperFactory>().GetTypeMapper());
                x.For<IConfiguration>().Singleton().Add(Configuration);
                x.For<Container>().Singleton().Add(Services);
                x.For<ICommandManager>().Singleton().Use<CommandManager>();
                x.For<IAppStorage>().Singleton().Use<AppStorage>();
                x.For<ICommandBus>().Use<CommandBus>();
                x.AddRouting();
            });
            Services.GetInstance<ITypeMapperFactory>().Configure(new TypeConverterDefaultProfile());
            CommandManager = Services.GetInstance<ICommandManager>();
        }

        protected void InitLoggers()
        {
            LogManager.Configuration = new NLogLoggingConfiguration(Configuration.GetSection("NLog"));
            MessengerManager.SetConfiguration(Configuration);
            RequesterManager.SetConfiguration(Configuration);
        }

        protected IConfiguration CreateConfiguration()
        {
            var config = new ConfigurationBuilder();
            config.AddJsonFile("appsettings.json");
            return config.Build();
        }

        /// <summary>
        /// Puts core into standby mode
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
