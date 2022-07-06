using System;
using System.Collections.Generic;
using Currency;
using Newtonsoft.Json;

namespace Player
{
    [Serializable]
    public class MutablePlayerData : ReadOnlyPlayerData
    {
        [JsonIgnore] public new List<MutableCurrencyData> Bank => _bank;

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetHighScore(int score)
        {
            HighScore = score;
        }
    }
}