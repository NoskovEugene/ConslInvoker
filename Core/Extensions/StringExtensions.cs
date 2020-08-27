using System.Linq;
using System;
namespace Core.Extensions
{
    public static class StringExtensions
    {
        public static string[] Split(this string str, params string[] separators)
        {
            return str.Split(separators);
        }

        public static string[] Split(this string str, StringSplitOptions options, params string[] separators)
        {
            return str.Split(separators,options);
        }
    }
}