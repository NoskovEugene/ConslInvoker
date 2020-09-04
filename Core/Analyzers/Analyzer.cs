using System;
using System.Linq;

using Core.Extensions;
using Models;   

namespace Core.Analyzers
{
    public class Analyzer : IAnalyzer
    {
        public IAnalyzer NextAnalyzer { get; set; }

        public Package Analyze(Package package)
        {
            var array = package.UnparsedString.Split(StringSplitOptions.RemoveEmptyEntries, " ");
            if(array.Length == 0){
                throw new ArgumentNullException("Input line cannot be empty");
            }
            package.Command = array[0];
            array = array.Where(x=> x != package.Command).ToArray();
            package.Parameter = string.Join(" ", array);
            if(NextAnalyzer != null)
                package = NextAnalyzer.Analyze(package);
            return package;
        }
    }
}