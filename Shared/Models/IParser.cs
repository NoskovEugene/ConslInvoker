using System;
using System.Collections.Generic;
namespace Shared.Models
{
    public interface IParser
    {
        void Parse(Package package, NeedRout rout);

        Dictionary<string, object> Parameters { get; }

        bool Success { get; set; }

        string ExceptionMessage { get; set; }

        Exception Exception { get; set; }
    }
}