using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using Routing.Models;

namespace Routing.Services
{


    public class UtilityController : IUtilityController
    {
        public List<Utility> Utilities { get; set; }

        protected IEnumerable<Utility> Query { get; set; }

        public int QueryCount { get; set; }

        public bool Success { get; set; }

        public UtilityController Match(string name)
        {
            Query = Utilities.Where(x => x.Name == name);
            QueryCount = Query.Count();
            Success = Query.Count() > 0;
            return this;
        }

        public Utility Next()
        {
            var utility = Query.FirstOrDefault();
            Query = Query.Where(x => x != utility);
            QueryCount = Query.Count();
            Success = Query.Count() > 0;
            return utility;
        }

        public void AddUtility(Utility utility)
        {
            if (!Match(utility.Name).Success)
            {
                Utilities.Add(utility);
            }

        }
    }
}