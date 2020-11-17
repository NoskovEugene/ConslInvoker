using System;
using System.Collections.Generic;
namespace Shared.Models
{
    public interface IParser
    {
        void Parse(Package package);

        Dictionary<string, object> Parameters { get; set; }

        bool Success { get; set; }

        string ExceptionMessage { get; set; }

        Exception Exception { get; set; }
    }
}