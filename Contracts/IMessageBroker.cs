namespace Contracts
{
    public interface IMessageBroker<TMessage>
    {
        // Subskrybuj handlera do otrzymywania wiadomości
        void Subscribe(IMessageHandler<TMessage> handler);
        void Unsubscribe(IMessageHandler<TMessage> handler);
        // Publikuj wiadomość — broker przekaże ją wszystkim subskrybentom
        void Publish(TMessage message);
    }
    // Generyczny interfejs
    public interface IMessageHandler<TMessage>
    {
        // Metoda wywoływana przez broker, gdy przychodzi nowa wiadomość

        void Handle(TMessage message);
    }
    // Interfejs dla modułów, start/stop
    public interface IModule
    {
        void Start();
        void Stop();
    }
}

