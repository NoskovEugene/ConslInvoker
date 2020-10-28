using System.Collections.Generic;
namespace Routing.Models
{
    public class Utility : NamedEntity
    {
        public List<Rout> Routs { get; set; }

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
            foreach(var item in Routs)
            {
                outS += $"{item.ToString("->")}";
            }
            return "";
        }
    }
}