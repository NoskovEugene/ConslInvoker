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

namespace Routing
{
    public class Router
    {


        protected List<Utility> Utilities { get; set; }

        protected Container Services { get; set; }

        public Router(Container services)
        {
            this.Services = services;
            Initialize();
        }

        private void Initialize()
        {
            Utilities = new List<Utility>();
        }

        public void AddApi<T>()
        {
            var type = typeof(T);
            var utilityAttribute = type.GetCustomAttribute<UtilityAttribute>();
            if (utilityAttribute != null)
            {
                var utility = new Utility
                {
                    UtilityType = type,
                    Name = utilityAttribute.UtilityName,
                };
                var methods = type.GetMethods();
                methods.Foreach(method =>
                {
                    var routAttribute = method.GetCustomAttribute<RoutAttribute>();
                    if (routAttribute != null)
                    {
                        var rout = GetRout(method,utility.Name,routAttribute);
                        utility.Routs.Add(rout);
                    }
                });
                Utilities.Add(utility);
            }
        }

        

    }
}
