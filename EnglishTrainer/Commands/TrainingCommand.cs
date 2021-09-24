using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Args;

namespace EnglishTrainer.Commands
{
    class TrainingCommand : IChatCommand
    {

        public TrainingCommand(ITelegramBotClient botClient)
        {

        }

        public bool CheckMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
