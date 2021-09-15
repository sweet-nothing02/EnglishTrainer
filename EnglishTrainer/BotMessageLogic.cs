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
    class BotMessageLogic
    {
        private Messenger messenger;

        private Dictionary<long, Conversation> chatList;

        private ITelegramBotClient botClient;

        public BotMessageLogic(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
            messenger = new Messenger();
            chatList = new Dictionary<long, Conversation>();
        }

        public async Task Response(MessageEventArgs e)
        {
            var Id = e.Message.Chat.Id;

            if (!chatList.ContainsKey(Id))
            {
                var newChat = new Conversation(e.Message.Chat);

                chatList.Add(Id, newChat);
            }
        }
    }
}
