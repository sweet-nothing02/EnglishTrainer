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
    public class Conversation
    {
        private Chat telegramChat;

        private List<Message> telegramMessages;

        public Dictionary<string, Word> dictionary;

        public bool IsAddingInProcess;

        public bool IsTraningInProcess;

        public Conversation(Chat chat)
        {
            telegramChat = chat;
            telegramMessages = new List<Message>();
            dictionary = new Dictionary<string, Word>();
        }

        public void AddMessage(Message message)
        {
            telegramMessages.Add(message);
        }

        public void AddWord(string key, Word word)
        {
            dictionary.Add(key, word);
        }

        public void ClearHistory()
        {
            telegramMessages.Clear();
        }

        public List<string> GetTextMessages()
        {
            var textMessages = new List<string>();

            foreach (var message in telegramMessages)
            {
                if (message.Text != null)
                {
                    textMessages.Add(message.Text);
                }
            }

            return textMessages;
        }

        public long GetId() => telegramChat.Id;

        public string GetLastMessage() => telegramMessages[telegramMessages.Count - 1].Text;

        public string GetTrainingWord(TrainingType type)
        {
            var rand = new Random();
            var item = rand.Next(0, dictionary.Count);

            var randomword = dictionary.Values.AsEnumerable().ElementAt(item);

            var text = string.Empty;

            switch (type)
            {
                case TrainingType.EngToRus:
                    text = randomword.Eng;
                    break;

                case TrainingType.RusToEng:
                    text = randomword.Rus;
                    break;
            }

            return text;
        }

        public bool CheckWord(TrainingType type, string word, string answer)
        {
            Word control;

            var result = false;

            switch (type)
            {

                case TrainingType.EngToRus:

                    control = dictionary.Values.FirstOrDefault(x => x.Eng == word);

                    result = control.Rus == answer;

                    break;

                case TrainingType.RusToEng:
                    control = dictionary[word];

                    result = control.Eng == answer;

                    break;
            }

            return result;
        }

    }
}
