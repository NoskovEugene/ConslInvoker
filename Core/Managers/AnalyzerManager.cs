using System;
using System.Reflection;

using StructureMap;

using Core;
using Core.Analyzers;

using Models;
using UI.MessengerUI;

namespace Core.Managers
{
    public class AnalyzerManager : IAnalyzerManager
    {

        protected Container Services { get; set; }

        protected IMessenger Messenger { get; set; }

        public AnalyzerManager(Container services, IMessenger messenger)
        {
            Services = services;
            Messenger = messenger;
        }

        public IAnalyzer RootAnalyzer { get; set; }

        public void AddAnalyzer<T>()
            where T : IAnalyzer
        {
            if (RootAnalyzer == null)
            {
                RootAnalyzer = Activator.CreateInstance<T>();
                return;
            }

            var analyzer = RootAnalyzer;
            var nextAnalyzer = RootAnalyzer.NextAnalyzer;
            while (true)
            {
                if (nextAnalyzer == null)
                {
                    var instanse = Activator.CreateInstance<T>();
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
            var analyzer = RootAnalyzer.NextAnalyzer;
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

            try
            {
                package = RootAnalyzer.Analyze(package);
            }
            catch(Exception ex)
            {
                Messenger.Fatal("Unhandled fatal error during analysis phase");
                Messenger.Trace(ex.Message);
            }
            return RootAnalyzer.Analyze(package);
        }
    }
}
