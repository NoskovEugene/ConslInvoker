using System;
using System.Text.RegularExpressions;

namespace Routing.Services
{
    public class Profile
    {
        public int Id { get; set; }

        public bool Remove { get; set; }

        public string RegexPattern { get; set; }

        public Regex CurrentRegex { get; set; }

        public string InputLine { get; set; }

        public Action<string> UpdateAction { get; set; }
    }
}
