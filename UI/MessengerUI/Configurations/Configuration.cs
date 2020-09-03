using System.Net.NetworkInformation;
using System.ComponentModel;
using UI.MessengerUI.Enums;
namespace UI.MessengerUI.Configurations
{
    public class Configuration
    {
        /// <summary>
        /// Шаблон сообщения
        /// </summary>
        /// <value></value>
        public string Pattern { get; set; }

        /// <summary>
        /// Минимальный уровень сообщения
        /// </summary>
        /// <value></value>
        public MessageType MinLevel { get; set; }

        /// <summary>
        /// Профиль Trace. Используется при отладке.
        /// </summary>
        /// <value></value>
        public Profile TraceProfile { get; set; }

        /// <summary>
        /// Профиль фатальных ошибок
        /// </summary>
        /// <value></value>
        public Profile FatalProfile { get; set; }

        /// <summary>
        /// Профиль ошибок
        /// </summary>
        /// <value></value>
        public Profile ErrorProfile { get; set; }

        /// <summary>
        /// Профиль предупреждений
        /// </summary>
        /// <value></value>
        public Profile WarnProfile { get; set; }

        /// <summary>
        /// Профиль информации
        /// </summary>
        /// <value></value>
        public Profile InfoProfile { get; set; }
    }
}