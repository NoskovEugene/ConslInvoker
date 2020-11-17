using System.Collections.Generic;
using Routing.Models;

namespace Routing.Services
{
    public interface IUtilityController
    {
        List<Utility> Utilities { get; set; }

        int QueryCount { get; set; }

        bool Success { get; set; }


        void AddUtility(Utility utility);

        UtilityController Match(string name);

        Utility Next();
    }
}