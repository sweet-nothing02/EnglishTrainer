using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using EnglishTrainer.Commands;

namespace EnglishTrainer
{
    public class Messenger
    {
        private ITelegramBotClient botClient;
        private CommandParser parser;

        public Messenger(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
            parser = new CommandParser();

            RegisterCommands();
        }

        private void RegisterCommands()
        {
            parser.AddCommand(new SayHiCommand());
            parser.AddCommand(new AddWordCommand(botClient));
            parser.AddCommand(new DeleteWordCommand());
            parser.AddCommand(new TrainingCommand(botClient));
            parser.AddCommand(new StopTrainingCommand());
        }

        public async Task MakeAnswer(Conversation chat)
        {
            var lastMessage = chat.GetLastMessage();

            if(chat.IsTraininginProcess && !parser.IsTextCommand(lastMessage))
            {
                parser.
            }

        }
    }
}
