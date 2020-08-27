using Models;
namespace Core.Managers
{
    public interface ICommandManager
    {
        void RegistryCommand<CommandType>()
            where CommandType : ICommand;

        void RegistryCommandUseAttribute<CommandType>()
            where CommandType : ICommand;

        ICommand GetCommand(string name);

        ICommand GetCommand<T>(string name);

        ICommand GetCommand<T>();

        bool TryFoundCommand(string name, out ICommand command);
    }
}