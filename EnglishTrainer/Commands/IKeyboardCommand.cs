using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace EnglishTrainer.Commands
{
    interface IKeyboardCommand
    {
        InlineKeyboardMarkup ReturnKeyboard();

        void AddCallBack(Conversation chat);

        string InformationalMessage();
    }
}
