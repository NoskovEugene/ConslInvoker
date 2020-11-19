using System;
using System.Collections.Generic;
using Shared.Models.Packages;

namespace Shared.Models.Router
{
    public interface IParser
    {

		/// <summary>
		///	Parse method
		/// </summary>
		/// <param name="package"></param>
		/// <param name="rout"></param>
        void Parse(Package<UserPackage> package, NeedRout rout);

		/// <summary>
		///	parsed parameters
		/// </summary>
		/// <value></value>
        Dictionary<string, object> Parameters { get; }

		/// <summary>
		///	flag for bus
		/// </summary>
		/// <value></value>
        bool Success { get; set; }

		/// <summary>
		///	Custom exception message
		/// </summary>
		/// <value></value>
        string ExceptionMessage { get; set; }

		/// <summary>
		/// Exception from parse step
		/// </summary>
		/// <value></value>
        Exception Exception { get; set; }
    }
}
