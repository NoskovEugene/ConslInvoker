using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;

using Routing.Models;
using Shared.Attributes;
using Shared.Extensions;
using System.Text.RegularExpressions;
using Routing.Extensions;
using Routing.Services;
using Shared.Models;

namespace Routing
{
    public class Router
    {
        protected APIParser APIParser { get; set; }

        protected List<Utility> Utilities { get; set; }

        protected Container Services { get; set; }

        protected IStringService StringService { get; set; }

        protected IMap Map { get; set; }

        public Router(Container services, IStringService stringService)
        {
            this.Services = services;
            this.StringService = stringService;
            Initialize();
        }

        private void Initialize()
        {
            Utilities = new List<Utility>();
        }

        public void AddApi<T>()
        {
            var utility = APIParser.GetApiMap<T>();

            if(utility != null)
            {
                Map.AddUtility(utility);
            }
        }

        public NeedRout GetRout(Package package)
        {
            var parameters = package.Parameter.Split(' ');
            return Map.Query(package.Utility, package.Command, parameters);
        }
    }
}
