
namespace Models
{
    public interface ICommand
    {
        string Command {get;}

        string Description {get;}

        void Execute(Package package);

    }
}