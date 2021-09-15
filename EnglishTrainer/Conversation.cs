using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace EnglishTrainer
{
    class Conversation
    {
        private Chat telegramChat;

        private List<Message> telegramMessages;

        public Dictionary<string, Word> dictionary;


        public Conversation(Chat chat)
        {

        }

        public long GetId()
        {
            return telegramChat.Id;
        }
    }
}
