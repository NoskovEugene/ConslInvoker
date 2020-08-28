namespace UI.MessengerUI
{
    public interface IMessenger
    {
        void Info(string message);

        void Warn(string message);

        void Error(string message);

        void Fatal (string message);
    }
}