using System;
using System.Collections;
using System.Collections.Generic;
namespace Shared.Models
{
    /// <summary>
    /// Внутренний пакет
    /// </summary>
    public class Package
    {
        public Package()
        {
            ParsedParameter = new Dictionary<string, object>();
        }

        public Package(string command, string parameter, string unparsedString) : base()
        {
            Command = command;
            Parameter = parameter;
            UnparsedString = unparsedString;

        }
        /// <summary>
        /// Входная строка
        /// </summary>
        /// <value></value>
        public string UnparsedString { get; set; }

        /// <summary>
        /// Имя утилиты
        /// </summary>
        /// <value></value>
        public string Utility { get; set; }

        /// <summary>
        /// Команда
        /// </summary>
        /// <value></value>
        public string Command { get; set; }

        /// <summary>
        /// Параметры
        /// </summary>
        /// <value></value>
        public string Parameter { get; set; }

        /// <summary>
        /// Позволяет отследить, были ли ошибки на этапах
        /// </summary>
        /// <value></value>
        public bool ExistException { get; set; }

        /// <summary>
        /// Преобразованные параметры
        /// </summary>
        /// <value></value>
        public Dictionary<string, object> ParsedParameter { get; set; }
    }
}