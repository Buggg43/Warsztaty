using Contracts;

namespace One
{
    /// <summary>
    /// Mediator + Singleton: broker wiadomości dla dowolnego typu TMessage.
    /// </summary>
    public class MessageBroker<TMessage> : IMessageBroker<TMessage>
    {
        private static readonly MessageBroker<TMessage> _instance = new MessageBroker<TMessage>();
        public static MessageBroker<TMessage> Instance => _instance;

        private readonly List<IMessageHandler<TMessage>> _subscribers = new List<IMessageHandler<TMessage>>();

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
            foreach (var sub in _subscribers)
            {
                sub.Handle(message);
            }
        }
    }
}
