using System;
using System.Text.RegularExpressions;
namespace Routing.Extensions
{
    public static class StringExtensions
    {
        public static (string result,string input) GetAndRemove(this string input, Regex regex)
        {
            var res = regex.Match(input).Value;
            input = input.Replace(res,string.Empty);
            return (res,input);
        }
    }
}