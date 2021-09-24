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
    class StopTrainingCommand : IChatCommand
    {
        public bool CheckMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
