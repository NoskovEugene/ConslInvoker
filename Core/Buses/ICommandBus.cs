using SharedModels;

namespace Core.Buses
{
    public interface ICommandBus
    {
        /// <summary>
        /// Execute command bus.
        /// </summary>
        /// <param name="line"></param>
        void Execute(string line);
    }
}