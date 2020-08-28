using System;
using System.Collections;
using System.Collections.Generic;

namespace UI.Processors
{
    public class StringProcessor
    {
        public Dictionary<string, Func<string,string>> Expressions { get; set; } = new Dictionary<string, Func<string,string>>
        {
            {"$\"{message}\"",(message) => message }
        };

        public string Replace(string pattern, string message)
        {

        }
    }
}