using Contracts;

namespace Two
{
    public class ModuleTwoWithStrategy : IModule, IMessageHandler<string>
    {
        private readonly IMessageBroker<string> _broker;
        private readonly IMessageProcessingStrategy _strategy;

        public ModuleTwoWithStrategy(IMessageBroker<string> broker, IMessageProcessingStrategy strategy)
        {
            _broker = broker;
            _strategy = strategy;
            _broker.Subscribe(this);
        }

        public void Start()
        {
            Console.WriteLine("[Two-Strat] Uruchamiam moduł TwoWithStrategy");
            var msg = "Hi from TwoWithStrategy!";
            Console.WriteLine($"[Two-Strat] Wysyłam: {msg}");
            _broker.Publish(msg);
        }

        public void Stop()
        {
            Console.WriteLine("[Two-Strat] Zatrzymuję moduł TwoWithStrategy");
            _broker.Unsubscribe(this);
        }

        public void Handle(string message)
        {
            _strategy.Process(message);
        }
    }
}

