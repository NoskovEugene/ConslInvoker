using Models;

namespace Core.Buses
{
    public interface ICommandBus
    {
        /// <summary>
        /// Execute command bus. s
        /// </summary>
        /// <param name="line"></param>
        void Execute(string line);
    }
}