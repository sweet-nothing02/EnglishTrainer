using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Commands
{
    class DeleteWordCommand : ChatTextCommandOption, IChatTextCommandWithAction
    {
        public DeleteWordCommand()
        {
            CommandText = "/deleteword";
        }

        public bool DoAction(Conversation chat)
        {
            var message = chat.G
        }

        public string ReturnText()
        {
            throw new NotImplementedException();
        }
    }
}
