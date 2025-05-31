using Contracts;

namespace Two
{
    public class Strategy :IModule, IMessageHandler<string>
    {
        private readonly IMessageBroker<string> _broker;
        private readonly IMessageProcessingStrategy _strategy;

        public Strategy(IMessageBroker<string> broker, IMessageProcessingStrategy strategy)
        {
            _broker = broker;
            _strategy = strategy;
            _broker.Subscribe(this);
        }

        public void Start()
        {
            Console.WriteLine("[Two-Strat] Uruchamiam moduł TwoWithStrategy");
            var msg = "Hi from TwoWithStrategy!";
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"[Two-Strat] Wysyłam: {msg}");
            _broker.Publish(msg);
        }

        public void Stop()
        {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("[Two-Strat] Zatrzymuję moduł TwoWithStrategy");
            _broker.Unsubscribe(this);
        }

        public void Handle(string message)
        {
            _strategy.Process(message);
        }
    }

}
