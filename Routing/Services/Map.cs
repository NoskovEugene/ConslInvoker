using System;
using System.Linq;
using System.Collections.Generic;
using Routing.Services;
using Shared.Models;

namespace Routing.Services
{


    public class Map : IMap
    {
        protected IUtilityController UtilityController { get; set; }

        public Map()
        {
            UtilityController = new UtilityController();
        }

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

        public void SetParserInstanse(Type parser, object instanse)
        {
            UtilityController.Update(x => x.ParserExists && x.ParserType == parser, x => x.ParserInstanse = instanse);
        }

        public void SetUtilityInstanse(Utility utility, object instanse)
        {
            UtilityController.Update(x => x.Equals(utility), x => x.UtilityInstanse = instanse);
        }
    }
}
