namespace UI.MessengerUI.Configurations
{
    public class Configuration
    {
        public string Pattern { get; set; }

        public Profile FatalProfile { get; set; }

        public Profile ErrorProfile { get; set; }

        public Profile WarnProfile { get; set; }

        public Profile InfoProfile { get; set; }
    }
}