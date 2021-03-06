using System;
using System.Collections.Generic;

using UI.MessengerUI.Enums;
namespace UI.MessengerUI.Processors
{
    public static class StringProcessor
    {
        public static string Expand(string pattern, string message, MessageType messengerType)
        {
            pattern = pattern.Replace("${message}", message)
                             .Replace("${messagetype}", messengerType.ToString().ToUpper())
                             .Replace("${shortdate}", DateTime.Now.ToString("dd:MM:yyyy"))
                             .Replace("${date}", DateTime.Now.ToString());
            return pattern;
        }
    }
}