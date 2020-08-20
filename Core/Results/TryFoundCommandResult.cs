using Models;

namespace Core.Results
{
    public class TryFoundCommandResult
    {
        public bool CommandFounded{get;set;}

        public ICommand Command{get;set;}

        public TryFoundCommandResult(bool commandFounded, ICommand commad = null){
            CommandFounded = commandFounded;
            Command = commad;
        }
    }
}