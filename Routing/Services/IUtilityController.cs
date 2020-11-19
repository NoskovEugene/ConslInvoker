using System;
using Shared.Models.Router;

namespace Routing.Services
{
    public interface IUtilityController
    {
        int QueryCount { get; set; }

        bool Success { get; set; }


        void AddUtility(Utility utility);

        UtilityController Match(string name);

        Utility Next();

        void Update(Func<Utility, bool> filter, Action<Utility> updateAction);
    }
}
