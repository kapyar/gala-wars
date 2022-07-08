using System;
using System.Collections.Generic;
using Currency;
using GameState;
using Newtonsoft.Json;

namespace Player.Data
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

        public void SetShipId(string id)
        {
            ShipId = id;
        }

        public void SetCombatSystemId(CombatSystemType id)
        {
            CombatSystemID = (int)id;
        }
    }
}