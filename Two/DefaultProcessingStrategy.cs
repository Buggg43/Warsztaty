namespace Two
{
    public class DefaultProcessingStrategy : IMessageProcessingStrategy
    {
        public void Process(string message)
        {
            Console.WriteLine($"[Two Strategy] Przetwarzam wiadomość: {message}");
        }
    }
}
