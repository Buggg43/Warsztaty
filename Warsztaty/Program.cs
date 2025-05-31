using System;
using Contracts;
using One;
using Two;

namespace Warsztaty
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Pobranie globalnej instancji brokera (Singleton z biblioteki Contracts)
            IMessageBroker<string> broker = MessageBroker<string>.Instance;

            // 2. Utworzenie modułów, wstrzykujemy tę samą instancję brokera
            var moduleOne = new ModuleOne(broker);
            var moduleTwo = new ModuleTwo(broker);

            // 3. Uruchamiamy moduły
            Console.WriteLine("== Start modułów ===");
            moduleOne.Start();
            moduleTwo.Start();

            System.Threading.Thread.Sleep(500);

            // 4. Zatrzymanie modułów
            Console.WriteLine("== Stop modułów ===");
            moduleOne.Stop();
            moduleTwo.Stop();

            Console.WriteLine("naciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }
    }
}
