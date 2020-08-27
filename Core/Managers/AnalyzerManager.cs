using System;
using System.Reflection;

using StructureMap;

using Core;
using Core.Analyzers;

using Models;

namespace Core.Managers
{
    public class AnalyzerManager : IAnalyzerManager
    {

        protected Container Services { get; set; }

        public AnalyzerManager(Container services)
        {
            this.Services = services;
        }

        public IAnalyzer ParentAnalyzer { get; set; }

        public void AddAnalyzer<T>()
        {
            var analyzer = ParentAnalyzer;
            var nextAnalyzer = ParentAnalyzer.NextAnalyzer;
            while (true)
            {
                if (nextAnalyzer == null)
                {
                    var instanse = (IAnalyzer)Activator.CreateInstance(typeof(T));
                    analyzer.NextAnalyzer = instanse;
                    break;
                }
                else
                {
                    analyzer = nextAnalyzer;
                    nextAnalyzer = analyzer.NextAnalyzer;
                }
            }
        }

        public void RemoveLastAnalyzer()
        {
            var analyzer = ParentAnalyzer.NextAnalyzer;
            var nextAnalyzer = analyzer.NextAnalyzer;
            while (true)
            {
                if (nextAnalyzer.NextAnalyzer == null)
                {
                    analyzer.NextAnalyzer = null;
                    break;
                }
                else
                {
                    analyzer = nextAnalyzer;
                    nextAnalyzer = analyzer.NextAnalyzer;
                }
            }
        }

        public Package Analyze(string line)
        {
            var package = new Package()
            {
                UnparsedString = line
            };
            return ParentAnalyzer.Analyze(package);
        }
    }
}
