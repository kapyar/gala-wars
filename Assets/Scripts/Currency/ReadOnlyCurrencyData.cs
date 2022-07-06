using System;
using Newtonsoft.Json;

namespace Currency
{
    public class ReadonlyCurrencyData
    {
        [JsonProperty("Id")] public CurrencyType Id { get; protected set; }

        [JsonProperty("Amount")] public int Amount { get; protected set; }

        [JsonIgnore] public Action<int> OnAmountChanged;
    }
}