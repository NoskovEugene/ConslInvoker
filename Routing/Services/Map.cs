using System;
using System.Linq;
using System.Collections.Generic;
using Routing.Services;
using Shared.Models;
using Shared.Models.Router;
using Shared.Models.Packages;

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

        public NeedRout Query(UserPackage package)
        {
            if (UtilityController.Match(package.Util).Success)
            {
                var needUtility = UtilityController.Next();
                return new NeedRout
                {
                    Utility = needUtility
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
