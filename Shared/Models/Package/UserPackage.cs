using System.Collections.Generic;
namespace Shared.Models.Packages
{
    public class UserPackage
    {
        public string UnparsedString { get; set; }

        public string Utility { get; set; }

        public string Command { get; set; }

        public string UnparsedParameters { get; set; }

        public List<string> Parameters { get; set; }

        public Dictionary<string, object> ParsedParameters { get; set; }
    }
}
