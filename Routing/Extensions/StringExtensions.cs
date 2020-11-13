using System;
using System.Text.RegularExpressions;
namespace Routing.Extensions
{
    public static class StringExtensions
    {
        public static (string removedResult, string outInput) GetAndRemove(this string input, Regex regex)
        {
            var res = regex.Match(input).Value;
            input = input.Replace(res, string.Empty);
            return (res, input);
        }

        public static bool MultiContains(this string line, params string[] items)
        {
            var outPut = false;
            foreach (var item in items)
            {
                if (line.Contains(item))
                {
                    outPut = true;
                }
            }
            return outPut;
        }
    }
}