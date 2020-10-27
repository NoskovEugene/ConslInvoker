using StructureMap;

namespace Routing
{
    public class Router : IRouter
    {
        protected Container Container { get; set; }

        public Router(Container container)
        {
            this.Container = container;
        }

        
    }
}