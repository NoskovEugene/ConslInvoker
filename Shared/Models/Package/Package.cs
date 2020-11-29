using System;
namespace Shared.Models.Packages
{
    public class Package
    {
        public string From { get; set; }
        public string To { get; set; }
        public Type FromType { get; set; }
        public Type ToType { get; set; }
        public PackageTypeEnum PackageType { get; set; }
    }
}
