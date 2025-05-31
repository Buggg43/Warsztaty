using Contracts;

namespace One
{
    public class ModuleOne : IModule, IMessageHandler<string>
    {
        private readonly IMessageBroker<string> _broker;

        public ModuleOne(IMessageBroker<string> broker)
        {
            _broker = broker;
            _broker.Subscribe(this);
        }

        public void Start()
        {
            Console.WriteLine("[One] Uruchamiam moduł One");
            System.Threading.Thread.Sleep(500);
            var msg = "Hello from One!";
            System.Threading.Thread.Sleep(500);
            Console.WriteLine($"[One] Wysyłam do brokera: {msg}");
            _broker.Publish(msg);
        }

        public void Stop()
        {
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("[One] Zatrzymuję moduł One");
            _broker.Unsubscribe(this);
        }

        public void Handle(string message)
        {
            System.Threading.Thread.Sleep(500);
            Console.WriteLine($"[One] Odebrałem wiadomość: {message}");
        }
    }
}
