using System.Collections.Generic;
using System.Linq;
using Shared.Models.Packages;
using Core.Managers;
using UI.MessengerUI;
using Shared.Extensions;

namespace Core.Buses
{
    public class CommandBus : ICommandBus
    {
        protected IMessenger Messenger { get; }

        protected IPackageCreator PackageCreator { get; set; }

        public CommandBus(IMessenger messenger, IPackageCreator packageCreator)
        {
            Messenger = messenger;
        }


        public void Execute(string line)
        {
            var userPackage = new UserPackage();
            userPackage.FromType = typeof(CommandBus);
            userPackage.ToType = typeof(PackageCreator);
            userPackage.InputLine = line;
            Messenger.Trace($"Input string '{line}'");
			var result = PackageCreator.Parse(userPackage);

			var exception = result.If(x=> x.PackageType == PackageTypeEnum.ExpectionPackage)
								  .Convert(x=> { return (ExceptionPackage)x;})
								  .Select(x=> new {
									  Context = x,
									  NotNull = x.NotNull()
								  });

			if(exception.NotNull)
			{
				
			}


            Messenger.Trace($"Trying find command {package.Command}");
            if (CommandManager.TryFoundCommand(package.Command, out var command))
            {
                Messenger.Trace($"Success. Finded '{command.GetType().Name}'");
                command.Execute(package);
            }
            else
            {
                Messenger.Fatal("Command not found");
            }
        }
    }
}
