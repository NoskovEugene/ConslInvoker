using Shared.Models.Packages;

namespace Core.Buses
{
    public interface IExecutor
    {
		void Execute(Package package);
    }
}
