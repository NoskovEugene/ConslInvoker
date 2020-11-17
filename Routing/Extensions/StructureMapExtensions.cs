using Routing;
using Routing.Services;

namespace StructureMap
{
    public static class StructureMapExtensions
    {
        public static void AddRouting(this ConfigurationExpression x)
        {
            x.For<IStringService>().Use<StringService>();
            x.For<IRouter>().Use<Router>();
        }
    }
}