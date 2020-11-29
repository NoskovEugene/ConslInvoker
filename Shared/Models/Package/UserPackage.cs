using System.Collections.Generic;
using Shared.Attributes;
namespace Shared.Models.Packages
{
	[PackageType(PackageTypeEnum.UserPackage)]
    public class UserPackage : Package
    {
		public UserPackage()
		{
			PackageType = PackageTypeEnum.UserPackage;
		}

        public string InputLine { get; set; }

        public string Util { get; set; }

        public string Command { get; set; }

        public string UnparsedParameters { get; set; }

        public string[] SplitedParams { get; set; }

        public Dictionary<string, object> ParsedParams { get; set; }

    }
}
