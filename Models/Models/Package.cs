namespace Models
{
    /// <summary>
    /// Внутренний пакет
    /// </summary>
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
        /// <summary>
        /// Входная строка
        /// </summary>
        /// <value></value>
        public string UnparsedString {get;set;}
        /// <summary>
        /// Команда
        /// </summary>
        /// <value></value>
        public string Command {get;set;}
        /// <summary>
        /// Параметры
        /// </summary>
        /// <value></value>
        public string Parameter {get;set;}
    }
}