using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer
{
    public class AddingController
    {
        private Dictionary<long, AddingState> ChatAdding;

        public AddingController()
        {
            ChatAdding = new Dictionary<long, AddingState>();
        }

        public void AddFirstState(Conversation chat)
        {
            ChatAdding.Add(chat.GetId(), AddingState.Russian);
        }

        public void NextStage(string message, Conversation chat)
        {
            var currentState = ChatAdding[chat.GetId()];
            ChatAdding[chat.GetId()] = currentState + 1;

            if(ChatAdding[chat.GetId()] == AddingState.Finish)
            {
                chat.IsAddingInProcess = false;
                ChatAdding.Remove(chat.GetId());
            }
        }

        public AddingState GetStage(Conversation chat)
        {
            return ChatAdding[chat.GetId()];
        }
    }
}
