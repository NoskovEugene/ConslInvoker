using System.Linq;
using System.Collections.Generic;
using Routing.Services;
using Routing.Models;

namespace Routing.Services
{


    public class Map : IMap
    {
        protected IUtilityController UtilityController { get; set; }

        public IMap AddUtility(Utility utility)
        {
            UtilityController.AddUtility(utility);
            return this;
        }

        public NeedRout Query(string utility, string command, string[] parameters)
        {
            if (UtilityController.Match(utility).Success)
            {
                var needUtility = UtilityController.Next();
                var rout = needUtility.Routs.Where(x =>
                    x.Name == command &&
                    x.Parameters.Count() == parameters.Length).FirstOrDefault();
                return new NeedRout
                {
                    Utility = needUtility,
                    Rout = rout
                };
            }
            else
            {
                return null;
            }
        }
    }
}
