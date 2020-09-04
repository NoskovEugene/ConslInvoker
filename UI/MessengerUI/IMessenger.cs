namespace UI.MessengerUI
{
    public interface IMessenger
    {
        void Trace(string message, bool createNewLine = true);

        void Info(string message, bool createNewLine = true);

        void Warn(string message, bool createNewLine = true);

        void Error(string message, bool createNewLine = true);

        void Fatal (string message, bool createNewLine = true);
    }
}