using Contracts;
using One;
using Two;

namespace Warsztaty
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Uzyskanie instancji brokera (Singleton)
            IMessageBroker<string> broker = MessageBroker<string>.Instance;

            // 2. (Opcjonalnie) utworzenie strategii dla modułu Two
            IMessageProcessingStrategy strategy = new DefaultProcessingStrategy();

            // 3. Tworzymy moduły:
            ModuleOne moduleOne = new ModuleOne(broker);
            var moduleTwo = new ModuleTwoWithStrategy(MessageBroker<string>.Instance, new DefaultProcessingStrategy());


            // sleep aby zobaczyć komunikaty

            // 4. Uruchamiamy moduły
            Console.WriteLine("=== Start modułów ===");
            moduleOne.Start();
            System.Threading.Thread.Sleep(500);
            moduleTwo.Start();

            
            System.Threading.Thread.Sleep(1000);

            // 6. Zatrzymanie modułów
            Console.WriteLine("=== Stop modułów ===");
            moduleOne.Stop();
            System.Threading.Thread.Sleep(500);
            moduleTwo.Stop();

            Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }
    }
}
