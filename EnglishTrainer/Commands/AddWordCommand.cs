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

        public async Task DoForStageAsync(AddingState addingState, Conversation chat, string message)
        {
            var word = Buffer[chat.GetId()];
            var text = "";

            switch (addingState)
            {
                case AddingState.Russian:
                    word.Rus = message;

                    text = "Введите слово на английском";
                    break;
                case AddingState.English:
                    word.Eng = message;

                    text = "Введите тематику";
                    break;
                case AddingState.Theme:
                    word.Theme = message;

                    text = $"Успешно! Слово {word.Eng} добавлено в словарь.";

                    chat.dictionary.Add(word.Rus, word);

                    Buffer.Remove(chat.GetId());
                    break;
            }

            await SendCommandText(text, chat.GetId());
        }

        private async Task SendCommandText(string text, long chat)
        {
            await botClient.SendTextMessageAsync(chatId: chat, text: text);
        }
    }
}
