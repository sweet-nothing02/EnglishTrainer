using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EnglishTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string token = "";
            var bot = new TelegramBotClient(token);
            bot.StartReceiving();
            var botClient = new BotWorker();

            botClient.Initialize();
            botClient.Start();

        }
    }
}
