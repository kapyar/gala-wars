using System;
using System.Collections.Generic;
using Currency;
using Newtonsoft.Json;

namespace PlayerState.Data
{
    [Serializable]
    public class ReadOnlyPlayerData
    {
        [JsonProperty("Name")] public string Name { get; protected set; }
        [JsonProperty("ShipId")] public string ShipId { get; protected set; }
        [JsonProperty("HighScore")] public int HighScore { get; protected set; }
        [JsonProperty("CombatSystemId")] public int CombatSystemID { get; protected set; }

        [JsonProperty("Bank")] protected List<MutableCurrencyData> _bank = new List<MutableCurrencyData>();

        [JsonIgnore] public IReadOnlyList<ReadonlyCurrencyData> Bank => _bank;
    }
}