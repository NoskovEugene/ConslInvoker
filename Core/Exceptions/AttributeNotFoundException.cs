namespace Core.Exceptions
{
    public class AttributeNotFoundException : System.Exception
    {
        public AttributeNotFoundException() : base("Attribute not found")
        {

        }


        public AttributeNotFoundException(string text) : base($"Attribute '{text}' was not found")
        {

        }
    }
}