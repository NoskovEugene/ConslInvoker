using System.Threading;
using System;
using System.Collections.Generic;
using Core.Managers;
using Core.Maps;
using Routing;
using Shared.Extensions;
using Shared.Models.Packages;

namespace Core.Buses
{
    public class MainExecutor : IExecutor
    {
        protected IRouter Router { get; set; }

        protected IPackageCreator PackageCreator { get; set; }

        public MainExecutor(IRouter router, IPackageCreator packageCreator)
        {
            Router = router;
            PackageCreator = packageCreator;
            Init();
        }

        public void Init()
        {
        }

        public void Execute(Package package)
        {
        }


    }
}
