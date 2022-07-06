using System;
using System.Collections.Generic;
using Currency;

namespace Player
{
    [Serializable]
    public class PlayerDto
    {
        public string Name;
        public int HighScore;
        public List<CurrencyDto> Bank = new List<CurrencyDto>();
    }
}