namespace Models
{
    public class Package
    {
        public Package()
        {
        }

        public Package(string command, string parameter,string unparsedString)
        {
            Command = command;
            Parameter = parameter;
            UnparsedString = unparsedString;
        }

        public string UnparsedString {get;set;}

        public string Command {get;set;}

        public string Parameter {get;set;}
    }
}