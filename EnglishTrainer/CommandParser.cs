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
    class CommandParser
    {
        private List<IChatCommand> Command;

        private AddingController addingControler;

        public CommandParser()
        {
            Command = new List<IChatCommand>();
            addingControler = new AddingController();
        }

        public void AddCommand(IChatCommand chatCommand)
        {
            Command.Add(chatCommand);
        }

        public bool IsMessageCommand(string message)
        {
            return Command.Exists(x => x.CheckMessage(message));
        }

        public bool IsTextCommand(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message));

            return command is IChatTextCommand;
        }

        public bool IsButtonCommand(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message));

            return command is IKeyboardCommand;
        }


    }
}
