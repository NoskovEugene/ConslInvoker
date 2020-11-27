
using Shared.Models.Packages;

namespace Shared.Models
{
    public interface ICommand
    {
        /// <summary>
        /// Строкое представление для вызова команды
        /// </summary>
        /// <value></value>
        string Command { get; }

        /// <summary>
        /// Объяснение по использованию
        /// </summary>
        /// <value></value>
        string Description { get; }

        /// <summary>
        /// Запуск команды
        /// </summary>
        /// <param name="package"></param>
        void Execute(Package package);

    }
}
