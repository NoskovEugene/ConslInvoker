using Models;

namespace Core.Buses
{
    public interface ICommandBus
    {
        void Execute(string line);
    }
}