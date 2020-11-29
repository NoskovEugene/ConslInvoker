using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Core.Extensions.StructureMapExtensions
{
    public class OptionFactory
    {
        public IOption<T> CreateOption<T>(IConfigurationSection section)
			where T : class, new()
        {
            var type = typeof(T);
            var instance = Activator.CreateInstance<T>();
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var prop in properties)
            {
                if (!prop.CanWrite) { break; }
                var setMethod = prop.GetSetMethod();
				var obj = section.GetValue(prop.PropertyType, prop.Name);
				if(obj != null)
				{
					setMethod.Invoke(instance, new object[] { obj });
				}
            }
			var option = new Option<T>(){
				Value = (T)instance
			};
			return option;
        }
    }
}
