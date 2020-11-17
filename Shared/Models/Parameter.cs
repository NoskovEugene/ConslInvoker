using System;
using System.Collections.Generic;
using System.Reflection;
namespace Shared.Models
{
    public class Parameter : NamedEntity
    {
        #region Fields

        public ParameterInfo ParameterInfo { get; set; }

        public Type ParameterType { get; set; }

        public bool IsSelectable { get; set; }

        public List<string> SelectableValues { get; set; }

        #endregion



        public string ToString(string prefix)
        {
            var outS = $"{prefix}Parameter {Name} with Type {ParameterInfo.ParameterType}";
            if (IsSelectable)
            {
                outS = $"{outS} will be:\r\n";
                foreach (var item in SelectableValues)
                {
                    outS += $"{prefix}{item}\r\n";
                }
                return outS.Trim('\r', '\n');
            }
            else
            {
                return outS;
            }
        }
    }
}