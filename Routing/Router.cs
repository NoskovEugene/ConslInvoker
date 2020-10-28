using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;

using Routing.Models;

using Shared.Attributes;
namespace Routing
{
    public class Router
    {
        private const string PARAMETER_PATTERN = @"\[.+?\]";
        private const string MULTIPLY_PARAMETERS = @"\{.+?\}";

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

        }

        private Rout GetRout(MethodInfo method)
        {
            var routAttribute = method.GetCustomAttribute<RoutAttribute>();


            return new Rout();
        }
    }
}
