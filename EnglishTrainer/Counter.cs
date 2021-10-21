using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer
{
    class Counter
    {
        private static int currentScore = 0;

        private static int totalNumber = 0;

        public static Func<int> scoreDelegate = Score;

        public static Func<int> totalNumberDelegate = TotalNumber;

        public static int Score()
        {
            return currentScore++;
        }

        public static int TotalNumber()
        {
            return totalNumber++;
        }

        public static double Mark(Func<int> score, Func<int> totalNumber)
        {
            var newScore = score();
            var newTotalNumber = totalNumber();
            return newScore / newTotalNumber;
        }
    }
}