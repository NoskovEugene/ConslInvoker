using Shared.Models.Packages;

namespace Core.Managers
{
    public interface IPackageCreator
    {
        Package Parse(Package package);
    }
}
