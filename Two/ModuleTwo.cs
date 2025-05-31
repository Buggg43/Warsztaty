using Contracts;

namespace Two
{
    public class ModuleTwo : IModule, IMessageHandler<string>
    {
        private readonly IMessageBroker<string> _broker;

        public ModuleTwo(IMessageBroker<string> broker)
        {
            _broker = broker;
            // Rejestrujemy się w brokerze od razu po utworzeniu instancji:
            _broker.Subscribe(this);
        }

        public void Start()
        {
            Console.WriteLine("[Two] Uruchamiam moduł Two");
            var message = "Hi from Two!";
            Console.WriteLine($"[Two] Wysyłam do brokera: {message}");
            _broker.Publish(message);
        }

        public void Stop()
        {
            Console.WriteLine("[Two] Zatrzymuję moduł Two");
            // Odsubskrybowujemy się, żeby nie otrzymywać dalszych wiadomości
            _broker.Unsubscribe(this);
        }

        public void Handle(string message)
        {
            // Metoda wywoływana przez brokera, kiedy nadchodzi nowa wiadomość
            Console.WriteLine($"[Two] Odebrałem wiadomość: {message}");
        }
    }
}

