using System;

namespace EnglishTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var botClient = new BotWorker();

            botClient.Initialize();
            botClient.Start();

        }
    }
}
