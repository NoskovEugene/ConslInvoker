using System;
namespace Shared.Attributes
{
    public class ParserAttribute : System.Attribute
    {
        /// <summary>
        /// You can use custom parser for yours utilities
        /// parser type should implement IParser interface
        /// </summary>
        /// <param name="parser"></param>
        public ParserAttribute(Type parser)
        {
            Parser = parser;
        }

        public Type Parser { get; set; }
    }
}