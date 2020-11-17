using System;
using System.Collections.Generic;
namespace Routing.Models
{
    public class Utility : NamedEntity
    {

        /// <summary>
        /// Тип класса утилиты
        /// </summary>
        /// <value></value>
        public Type UtilityType { get; set; }

        /// <summary>
        /// Роуты утилиты
        /// </summary>
        /// <value></value>
        public List<Rout> Routs { get; set; } = new List<Rout>();

        /// <summary>
        /// Объект утилиты
        /// </summary>
        /// <value></value>
        public object UtilityInstanse { get; set; }

        /// <summary>
        /// Существует ли парсер для данной утилиты
        /// </summary>
        /// <value></value>
        public bool ParserExists { get; set; }

        /// <summary>
        /// Тип парсера
        /// </summary>
        /// <value></value>
        public Type ParserType { get; set; }

        /// <summary>
        /// Объект парсера
        /// </summary>
        /// <value></value>
        public object Instanse { get; set; }

        public List<string> GetRoutNames
        {
            get
            {
                var lst = new List<string>();
                Routs.ForEach(x =>
                {
                    lst.Add($"{Name}:{x.Name}");
                });
                return lst;
            }
        }

        public override string ToString()
        {
            var outS = $"Utility {Name} with Routs:";
            foreach (var item in Routs)
            {
                outS += $"{item.ToString("->")}";
            }
            return "";
        }
    }
}