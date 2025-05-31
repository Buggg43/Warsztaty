using Contracts;

namespace One
{
    //implementuje IModule(Start/Stop) oraz odbiera wiadomości jako IMessageHandler<string>
    public class ModuleOne : IModule, IMessageHandler<string>
    {
        private readonly IMessageBroker<string> _broker;

        public ModuleOne(IMessageBroker<string> broker)
        {
            _broker = broker;
            // Rejestrujemy się w brokerze od razu po utworzeniu instancji:
            _broker.Subscribe(this);
        }

        public void Start()
        {
            Console.WriteLine("[One] Uruchamiam moduł One");
            var message = "Hello from One!";
            Console.WriteLine($"[One] Wysyłam do brokera: {message}");
            _broker.Publish(message);
        }

        public void Stop()
        {
            Console.WriteLine("[One] Zatrzymuję moduł One");
            // Odsubskrybowujemy się, żeby nie otrzymywać dalszych wiadomości
            _broker.Unsubscribe(this);
        }

        public void Handle(string message)
        {
            // Metoda wywoływana przez brokera, kiedy nadchodzi nowa wiadomość
            Console.WriteLine($"[One] Odebrałem wiadomość: {message}");
        }
    }
}
