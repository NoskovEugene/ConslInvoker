using Shared.Models.Packages;

namespace Shared.Attributes
{
    public class PackageTypeAttribute : System.Attribute
    {
        public PackageTypeAttribute(PackageTypeEnum packageType)
        {
            PackageType = packageType;
        }

        public PackageTypeEnum PackageType { get; set; }
    }
}
