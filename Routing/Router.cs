using System.Collections.Generic;

using StructureMap;

using Routing.Services;
using Shared.Models.Router;
using Shared.Models;
using Shared.Models.Packages;

namespace Routing
{
    public class Router : IRouter
    {
        const string PARSER_PREFIX = "parser";

        protected APIParser APIParser { get; set; }

        protected Container Services { get; set; }

        protected IMap Map { get; set; }

        public Router(Container services)
        {
            this.Services = services;
            Init();
        }

        private void Init()
        {
            APIParser = new APIParser();
            Map = new Map();
        }

        public void AddApi<T>()
        {
            var utility = APIParser.GetApiMap<T>();

            if (utility != null)
            {
                Map.AddUtility(utility);
                Services.Configure(x =>
                {
                    x.For<T>().Use<T>().Named(utility.Name);
                    if (utility.ParserExists)
                    {
                        var parserType = utility.ParserType;
                        x.For(parserType).Use(parserType).Named($"{utility.Name}{PARSER_PREFIX}");
                    }
                });
            }
        }

        public NeedRout GetRout(Package<UserPackage> package)
        {
            var needRout = Map.Query(package);
            if (needRout.Utility.UtilityInstanse == null)
            {
                var instanse = Services.GetInstance(needRout.Utility.UtilityType, needRout.Utility.Name);
                Map.SetUtilityInstanse(needRout.Utility, instanse);
                needRout.Utility.UtilityInstanse = instanse;
            }
            if (needRout.Utility.ParserExists && needRout.Utility.ParserInstanse == null)
            {
                var instanse = Services.GetInstance(needRout.Utility.ParserType, needRout.Utility.Name + PARSER_PREFIX);
                Map.SetParserInstanse(needRout.Utility.ParserType, instanse);
                needRout.Utility.ParserInstanse = instanse;
            }
            return needRout;
        }
    }
}
