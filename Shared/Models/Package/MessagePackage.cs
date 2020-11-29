using Shared.Attributes;

namespace Shared.Models.Packages
{
	[PackageType(PackageTypeEnum.MessagePackage)]
    public class MessagePackage : Package
    {
		public MessagePackage()
		{
			PackageType = PackageTypeEnum.MessagePackage;
		}

        public string Message { get; set; }
    }
}
