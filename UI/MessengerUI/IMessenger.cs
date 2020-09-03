namespace UI.MessengerUI
{
    public interface IMessenger
    {
        void Trace(string message);

        void Info(string message);

        void Warn(string message);

        void Error(string message);

        void Fatal (string message);
    }
}