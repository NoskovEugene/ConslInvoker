using System;
using StructureMap;

namespace Core
{
    public class InvokerCore
    {

        public Container Services {get;set;}

        public InvokerCore()
        {
            Services = new Container();
        }
        
    }
}