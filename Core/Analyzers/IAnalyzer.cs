using Models;

namespace Core.Analyzers
{
    public interface IAnalyzer
    {
        Package Analyze(Package package);

        IAnalyzer NextAnalyzer { get; set; }
    }
}