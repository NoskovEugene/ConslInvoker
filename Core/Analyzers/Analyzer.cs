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
            var command = array[0];
            var parameter = string.Join(" ", array);
            if(NextAnalyzer != null)
                package = NextAnalyzer.Analyze(package);
            return package;
        }
    }
}