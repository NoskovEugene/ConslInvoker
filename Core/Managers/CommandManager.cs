using Core.Exceptions;
using Infrastructure;
using Infrastructure.Attributes;
using Models;
using StructureMap;
using System;
using System.Reflection;    


namespace Core.Managers
{
    public class CommandManager : ICommandManager
    {
        protected Container Services {get; set;}

        public CommandManager(Container services)
        {
            Services = services;
        }

        public void RegistryNewCommand<CommandType>()
            where CommandType : ICommand
        {
            var name = typeof(CommandType).Name.Replace("Command",string.Empty);
            RegistryCommand<CommandType>(name);
        }

        public void RegistryNewCommandUseAttribute<CommandType>()
            where CommandType : ICommand
        {
            var type = typeof(CommandType);
            var attribute = type.GetCustomAttribute<CommandInfoAttribute>();
            if(attribute == null)
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

        public bool TryFoundCommand(string name, out ICommand command)
        {
            command = null;
            var model = Services.Model;
            foreach(var item in model.AllInstances)
            {
                if(item.Name.Equals(name, StringComparison.OrdinalIgnoreCase)){
                    command = GetCommand(item.Name);
                    return true;
                }
            }
            
            return false;
        }

        private void RegistryCommand<T>(string name)
            where T : ICommand
        {
            Services.Configure(x=> {
                x.For<ICommand>().Use<T>().Named(name);
            });
        }


    }
}