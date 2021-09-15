using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace EnglishTrainer.Commands
{
    class AddWordCommand : AbstractCommand
    {
        private ITelegramBotClient botClient;

        private Dictionary<long, Word> Buffer;

        public AddWordCommand(ITelegramBotClient botClient)
        {
            CommandText = "/addword";

            this.botClient = botClient;

            Buffer = new Dictionary<long, Word>();
        }

        public async void StartProcessAsync(Conversation chat)
        {
            Buffer.Add(chat.GetId(), new Word());

            var text = "Введите слово на русском";

            await SendCommandText(text, chat.GetId());
        }

        private async Task SendCommandText(string text, long chatNumber)
        {
            await botClient.SendTextMessageAsync(chatId: chatNumber, text: text);
        }
    }
}
