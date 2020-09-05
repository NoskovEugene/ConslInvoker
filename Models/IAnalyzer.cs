namespace Models
{
    /// <summary>
    /// Анализатор пакета
    /// </summary>
    public interface IAnalyzer
    {
        /// <summary>
        /// Анализирует пакет
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        Package Analyze(Package package);

        /// <summary>
        /// Следующий анализатор
        /// </summary>
        /// <value></value>
        IAnalyzer NextAnalyzer { get; set; }
    }
}