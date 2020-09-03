using System;

namespace Infrastructure.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class CommandInfoAttribute : Attribute
    {
        public string CommandRegistryName {get;set;}

        public CommandInfoAttribute(string commandRegistryName)
        {
            CommandRegistryName = commandRegistryName;
        }
    }
}