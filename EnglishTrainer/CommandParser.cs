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

        private AddingController addingController;

        public CommandParser()
        {
            Command = new List<IChatCommand>();
            addingController = new AddingController();
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

        public string GetMessageText(string message, Conversation chat)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IChatTextCommand;

            if(command is IChatTextCommandWithAction)
            {
                if(!(command as IChatTextCommandWithAction).DoAction(chat))
                {
                    return "Ошибка выполнения команды!";
                }
            }

            return command.ReturnText();
        }

        public string GetInformationalMessage(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IKeyboardCommand;

            return command.InformationalMessage();
        }

        public InlineKeyboardMarkup GetKeyboard(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IKeyboardCommand;

            return command.ReturnKeyboard();
        }

        public void AddCallback(string message, Conversation chat)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IKeyboardCommand;
            command.AddCallBack(chat);
        }

        public bool IsAddingCommand(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message));

            return command is AddWordCommand;
        }

        public void StartAdiingWord(string message, Conversation chat)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as AddWordCommand;

            addingController.AddFirstState(chat);
            command.StartProcessAsync(chat);
        }

        public void NextStage(string message, Conversation chat)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as AddWordCommand;

            command.DoForStageAsync(addingController.GetStage(chat), chat, message);

            addingController.NextStage(message, chat);
        }

        public void ContinueTraining(string message, Conversation chat)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as TrainingCommand;

            command.
        }
    }
}
