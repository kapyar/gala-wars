using System;
using System.Collections.Generic;
using Currency;
using Newtonsoft.Json;

namespace Player
{
    [Serializable]
    public class ReadOnlyPlayerData
    {
        [JsonProperty("Name")] public string Name { get; protected set; }
        [JsonProperty("HighScore")] public int HighScore { get; protected set; }

        [JsonProperty("Bank")] protected List<MutableCurrencyData> _bank = new List<MutableCurrencyData>();

        [JsonIgnore] public IReadOnlyList<ReadonlyCurrencyData> Bank => _bank;
    }
}