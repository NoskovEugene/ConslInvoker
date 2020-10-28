namespace Shared.Attributes
{
    public class RoutAttribute : System.Attribute
    {
        public string CommandInfo { get; set; }

        public string Parameters { get; set; }

        public string Flags { get; set; }
    }
}