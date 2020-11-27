using System.Runtime.Serialization;
using System;
using System.Reflection;
using Shared.Attributes;
using Shared.Models.Packages;

namespace Shared.Extensions
{
    public static class PackageExtensions
    {
        public static bool TryGetPayload<T>(this Package package, out T value)
        where T : Package
        {
            value = default(T);
            var attributeValue = GetPackageEnum(typeof(T));
            if (attributeValue != null && package.PackageType == attributeValue)
            {
                value = (T)package;
                return true;
            }
            else
            {
                return false;
            }
        }

		public static Package Swap(this Package package)
		{
			var fromGlass = package.From;
			var fromTypeGlass = package.FromType;
			package.From = package.To;
			package.FromType = package.ToType;
			package.To = fromGlass;
			package.ToType = fromTypeGlass;
			return package;
		}

        private static PackageTypeEnum? GetPackageEnum(Type type)
        {
            var attribute = type.GetCustomAttribute<PackageTypeAttribute>();
            if (attribute != null)
                return attribute.PackageType;
            else
                return null;
        }
    }
}
