using Models;

namespace Core.Managers
{
    public interface IAnalyzerManager
    {
        void AddAnalyzer<T>();

        void RemoveLastAnalyzer();

        Package Analyze(string line);

    }
}