using System;
using Shared.Models;
using Shared.Models.Packages;
using Shared.Models.Router;

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
        NeedRout Query(Package<UserPackage> package);

        /// <summary>
        /// Setup utility instanse from container
        /// </summary>
        /// <param name="utility"></param>
        /// <param name="instanse"></param>
        void SetUtilityInstanse(Utility utility, object instanse);


        /// <summary>
        /// Setup parser instanse from container
        /// </summary>
        /// <param name="parser"></param>
        /// <param name="instanse"></param>
        void SetParserInstanse(Type parser, object instanse);
    }
}
