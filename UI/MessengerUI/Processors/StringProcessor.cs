using System;
using System.Collections;
using System.Collections.Generic;

namespace UI.MessengerUI.Processors
{
    public class StringProcessor : IStringProcessor
    {
        public Dictionary<string, Func<string, string>> Expressions { get; set; } = new Dictionary<string, Func<string, string>>
        {
            {"$\"{message}\"",(message) => message }
        };

        public string Replace(string pattern, string message)
        {
            foreach (var item in Expressions)
            {
                if (pattern.Contains(item.Key))
                {
                    pattern = pattern.Replace(item.Key, item.Value(message));
                }
            }
            return pattern;
        }
    }
}