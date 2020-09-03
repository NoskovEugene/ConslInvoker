using UI.MessengerUI.Enums;
using UI.MessengerUI.InternalModels;

namespace UI.MessengerUI.Managers
{
    public interface IMessageManager
    {
        void Add(MessageEvent message);

        void Add(string message, MessageType messageType);
    }
}