using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer
{
    class Word
    {
        public string Eng { get; set; }
        public string Rus { get; set; }

        public string Theme { get; set; }

        public enum TrainingType
        {
            RusToEng,
            EngToRus
        }

        public enum State
        {
            Rusiian,
            English,
            Theme,
            Finish
        }
    }
}
