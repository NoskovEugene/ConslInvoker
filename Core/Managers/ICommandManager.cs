using Models;
namespace Core.Managers
{
    public interface ICommandManager
    {
        void RegistryNewCommand<CommandType>()
            where CommandType : ICommand;

        void RegistryNewCommandUseAttribute<CommandType>()
            where CommandType : ICommand;

        ICommand GetCommand(string name);

        bool TryFoundCommand(string name, out ICommand command);
    }
}