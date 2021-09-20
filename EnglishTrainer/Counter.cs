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
    public class Counter
    {
        public delegate long AddScoreDelegate(long currentScore);
        AddScoreDelegate score = AddScore;

        public static long AddScore(long currentScore)
        {
            return currentScore++;
        }

        public double GetMark(AddScoreDelegate score, Chat chat)
        {
            return score(0) / chat.Id;
        }
    }
}
