using System.Linq;
using Core.Exceptions;
using Infrastructure.Attributes;
using Shared.Models;
using StructureMap;
using System;
using System.Reflection;
using UI.MessengerUI;

namespace Core.Managers
{
    public class CommandManager : ICommandManager
    {
        protected Container Services { get; }

        protected IMessenger Messenger { get; }

        public CommandManager(Container services, IMessenger messenger)
        {
            Services = services;
            this.Messenger = messenger;
        }

        public void RegistryCommand<CommandType>()
            where CommandType : ICommand
        {
            var name = typeof(CommandType).Name.Replace("Command", string.Empty);
            RegistryCommand<CommandType>(name);
        }

        public void RegistryCommandUseAttribute<CommandType>()
            where CommandType : ICommand
        {
            var type = typeof(CommandType);
            var attribute = type.GetCustomAttribute<CommandInfoAttribute>();
            if (attribute == null)
            {
                throw new AttributeNotFoundException(nameof(CommandInfoAttribute));
            }
            var name = attribute.CommandRegistryName;
            RegistryCommand<CommandType>(name);
        }

        public ICommand GetCommand(string name)
        {
            return Services.GetInstance<ICommand>(name);
        }


        public ICommand GetCommand()
        {
            return Services.GetInstance<ICommand>();
        }


        public bool TryFoundCommand(string name, out ICommand command)
        {
            command = null;
            var model = Services.Model;
            var result = model.AllInstances.Where(x =>
                x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (result.Count() > 0)
            {
                command = GetCommand(result.First().Name);
                return true;
            }
            return false;
        }

        private void RegistryCommand<T>(string name)
            where T : ICommand
        {
            if (!TryFoundCommand(name, out _))
            {
                Services.Configure(x =>
                {
                    x.For<ICommand>().Use<T>().Named(name);
                });
            }
            else
            {
                Messenger.Trace($"Command '{name}' with type '{typeof(T).Name}' already exist in container. Command will be skipped");
            }

        }


    }
}