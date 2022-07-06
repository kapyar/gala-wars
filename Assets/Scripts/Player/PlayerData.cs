using System;
using System.Collections.Generic;
using Currency;

namespace Player
{
    [Serializable]
    public class PlayerData
    {
        public int HighScore;
        public string Name;
        public readonly List<CurrencyData> Bank = new List<CurrencyData>();

        
        public void FromDto(PlayerDto dto)
        {
            HighScore = dto.HighScore;
            Name = dto.Name;

            foreach (var currencyDto in dto.Bank)
            {
                var currencyData = new CurrencyData();

                Bank.Add(currencyData);
            }
        }
    }
}