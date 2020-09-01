using System.ComponentModel;
using System;

using UI.MessengerUI.Enums;

namespace UI.MessengerUI.Configurations
{
    public class Profile
    {
        public ConsoleColor ForegroundColor { get; set; } = ConsoleColor.White;

        public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;
    }
}