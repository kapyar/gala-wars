using System;
using System.Collections.Generic;
using Currency;

namespace Player
{
    [Serializable]
    public class PlayerDto
    {
        public float Name;
        public List<CurrencyDto> Bank;

        public int HighScore;
    }
}