using System.Runtime.CompilerServices;
using StructureMap;
using Microsoft.Extensions.Configuration;
namespace Core.Extensions.StructureMapExtensions
{
    public static class ContainerExtensions
    {
		public static Container ConfigureOption<T>(this Container container, IConfigurationSection section)
			where T: class, new()
		{
			var optionFactory = new OptionFactory();
			container.Configure(x=> {
				x.For<IOption<T>>().Singleton().Add(optionFactory.CreateOption<T>(section));
			});
			return container;
		}
    }
}
