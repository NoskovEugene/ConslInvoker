namespace Models
{
    public interface IAnalyzer
    {
        Package Analyze(Package package);

        IAnalyzer NextAnalyzer { get; set; }
    }
}