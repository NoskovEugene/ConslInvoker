namespace Shared.Attributes
{
    public class RoutAttribute : System.Attribute
    {
        public string CommandName { get; set; }

        public string Parameters { get; set; }

        public string Flags { get; set; }
    }
}