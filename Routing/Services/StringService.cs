using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace Routing.Services
{
    public class StringService
    {
        public const string PARAMETER_PATTERN = @"\[.+?\]";
        public const string SELECTABLE_PARAMETER_PATTERN = @"\{.+?\}";
        public Regex ParameterRegex {get;set;}
        public Regex SelectableParameterRegex {get;set;}

        public StringService()
        {
            
        }

    }
}