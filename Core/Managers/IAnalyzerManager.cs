using Models;

namespace Core.Managers
{
    public interface IAnalyzerManager
    {
        void AddAnalyzer<T>()
        where T : IAnalyzer;

        void RemoveLastAnalyzer();

        Package Analyze(string line);

    }
}