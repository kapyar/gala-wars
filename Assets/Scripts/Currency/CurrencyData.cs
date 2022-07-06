using System;
using Newtonsoft.Json;

namespace Currency
{
    public class CurrencyData : CurrencyDto
    {
        [JsonIgnore] public Action<int> OnAmountChanged;

        public CurrencyType Type { get => _type; set => _type = value; }

        public int Amount
        {
            get => _amount;
            set
            {
                OnAmountChanged?.Invoke(value);
                _amount = value;
            }
        }
    }
}