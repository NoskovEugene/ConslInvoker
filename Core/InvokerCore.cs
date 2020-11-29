using System;

using StructureMap;

using NLog;
using NLog.Extensions.Logging;

using Core.Storage;

using UI.MessengerUI;
using UI.Request;

using Shared.Models;

using Microsoft.Extensions.Configuration;
using Core.Managers;

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


        public InvokerCore()
        {
            Configuration = CreateConfiguration();
            InitLoggers();
            Services = new Container();
            Services.Configure(x =>
            {
                x.For<IRequester>().Use(x => RequesterManager.GetRequester());
                x.For<IMessenger>().Use(x => MessengerManager.GetMessenger());
                x.For<IConfiguration>().Singleton().Add(Configuration);
                x.For<Container>().Singleton().Add(Services);
                x.For<IAppStorage>().Singleton().Use<AppStorage>();
				x.For<IPackageCreator>().Use<PackageCreator>();
                x.AddRouting();
            });
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

        }
    }
}
