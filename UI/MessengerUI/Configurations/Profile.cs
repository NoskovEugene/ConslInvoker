using System.ComponentModel;
using System;

using UI.MessengerUI.Enums;

namespace UI.MessengerUI.Configurations
{
    public class Profile
    {
        [DefaultValue(ConsoleColor.White)]
        public ConsoleColor ForegroundColor { get; set; }

        [DefaultValue(ConsoleColor.Black)]
        public ConsoleColor BackgroundColor { get; set; }
    }
}