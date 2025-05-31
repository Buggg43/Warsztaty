namespace Contracts
{
    public interface IMessageBroker<TMessage>
    {
        void Subscribe(IMessageHandler<TMessage> handler);
        void Unsubscribe(IMessageHandler<TMessage> handler);
        void Publish(TMessage message);
    }

    public interface IMessageHandler<TMessage>
    {
        void Handle(TMessage message);
    }
}

