using Contracts;

namespace Contracts
{
    // Singleton + Mediator (Publish–Subscribe) dla dowolnego typu TMessage
    public class MessageBroker<TMessage> : IMessageBroker<TMessage>
    {
        // Jedyna instancja brokera dla TMessage
        private static readonly MessageBroker<TMessage> _instance = new MessageBroker<TMessage>();
        public static MessageBroker<TMessage> Instance => _instance;

        // Lista zarejestrowanych subskrybentów
        private readonly List<IMessageHandler<TMessage>> _subscribers = new List<IMessageHandler<TMessage>>();

        // Prywatny konstruktor, aby wymusić wzorzec Singleton
        private MessageBroker() { }

        public void Subscribe(IMessageHandler<TMessage> handler)
        {
            if (!_subscribers.Contains(handler))
                _subscribers.Add(handler);
        }

        public void Unsubscribe(IMessageHandler<TMessage> handler)
        {
            if (_subscribers.Contains(handler))
                _subscribers.Remove(handler);
        }

        public void Publish(TMessage message)
        {
            // Rozsyłanie wiadomości do wszystkich subskrybentów
            foreach (var sub in _subscribers)
            {
                sub.Handle(message);
            }
        }
    }
}
