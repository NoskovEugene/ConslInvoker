using System.Collections.Generic;
using System.Reflection;
namespace Routing.Models
{
    public class Parameter : NamedEntity
    {

        public ParameterInfo ParameterInfo { get; set; }

        public bool NeedChoose { get; set; }

        public List<string> EnabledValues { get; set; }

        public string ToString(string prefix)
        {
            var outS = $"{prefix}Parameter {Name} with Type {ParameterInfo.ParameterType}";
            if(NeedChoose)
            {
                outS = $"{outS} will be:\r\n";
                foreach(var item in EnabledValues)
                {
                    outS += $"{prefix}{item}\r\n";
                }
                return outS.Trim('\r','\n');
            }
            else
            {
                return outS;
            }
        }
    }
}