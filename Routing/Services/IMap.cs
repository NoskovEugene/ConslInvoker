using Routing.Models;

namespace Routing.Services
{
    public interface IMap
    {
        /// <summary>
        /// Registry new utility
        /// </summary>
        /// <param name="utility"></param>
        /// <returns></returns>
        IMap AddUtility(Utility utility);

        /// <summary>
        /// Query need rout using parmeters
        /// </summary>
        /// <param name="utility">Utility name</param>
        /// <param name="command">Command Name</param>
        /// <param name="parameters">Parameters</param>
        /// <returns></returns>
        NeedRout Query(string utility, string command, string[] parameters);
    }
}