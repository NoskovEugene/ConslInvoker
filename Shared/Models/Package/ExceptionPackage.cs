using System;
using Shared.Attributes;
namespace Shared.Models.Packages
{
	[PackageType(PackageTypeEnum.ExceptionPackage)]
    public class ExceptionPackage : MessagePackage
    {
		public ExceptionPackage()
		{
			PackageType = PackageTypeEnum.ExceptionPackage;
		}

        public Exception Exception { get; set; }
    }
}
