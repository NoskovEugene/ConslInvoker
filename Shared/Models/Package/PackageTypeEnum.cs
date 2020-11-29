using System.ComponentModel.DataAnnotations;

namespace Shared.Models.Packages
{
    public enum PackageTypeEnum
    {
		[Display(Name = "Package with user info")]
        UserPackage = 1,

		[Display(Name = "Intermediate package with message")]
        MessagePackage = 2,

		[Display(Name = "Intermediate package with exception")]
		ExceptionPackage = 3
    }
}
