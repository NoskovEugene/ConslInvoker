using System;
namespace Shared.Attributes
{
    public class ParserAttribute : System.Attribute
    {
        public ParserAttribute(Type parser)
        {
            Parser = parser;
        }

        public Type Parser { get; set; }
    }
}