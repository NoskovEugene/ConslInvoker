using Shared.Models;

namespace Core.Managers
{
    public interface IAnalyzerManager
    {
        /// <summary>
        /// Добавляет новый слой анализаторов
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void AddAnalyzer<T>()
        where T : IAnalyzer;

        /// <summary>
        /// Удаляет последний слой анализаторов
        /// </summary>
        void RemoveLastAnalyzer();

        /// <summary>
        /// Запускает процесс анализа входящей строки
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        Package Analyze(string line);

    }
}