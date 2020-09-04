using Models;
namespace Core.Managers
{
    public interface ICommandManager
    {
        /// <summary>
        /// Регистрирует новую команду
        /// </summary>
        /// <typeparam name="CommandType"></typeparam>
        void RegistryCommand<CommandType>()
            where CommandType : ICommand;

        /// <summary>
        /// Регистрирует новую команду используя аттрибут
        /// </summary>
        /// <typeparam name="CommandType"></typeparam>
        void RegistryCommandUseAttribute<CommandType>()
            where CommandType : ICommand;

        /// <summary>
        /// Получает комманду по имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ICommand GetCommand(string name);

        /// <summary>
        /// Получает последнюю команду
        /// </summary>
        /// <returns></returns>
        ICommand GetCommand();

        /// <summary>
        /// Предпринимается попытка найти команду по имени
        /// </summary>
        /// <param name="name"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        bool TryFoundCommand(string name, out ICommand command);
    }
}