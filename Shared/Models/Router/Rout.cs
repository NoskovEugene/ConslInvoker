using System.Collections.Generic;
using System.Reflection;
using System;
namespace Shared.Models.Router
{
    public class Rout : NamedEntity
    {
        public Type Class { get; set; }

        public MethodInfo Method { get; set; }

        public List<Parameter> Parameters { get; set; }

        public string ToString(string prefix)
        {
            var outS = $"{prefix}Rout {Name} to Method {Method.Name} with parameters:";
            foreach (var parameter in Parameters)
            {
                outS += parameter.ToString($"{prefix.Trim('>')}->");
            }
            return outS;
        }
    }
}
