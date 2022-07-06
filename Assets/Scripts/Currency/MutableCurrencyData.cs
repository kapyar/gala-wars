namespace Currency
{
    public class MutableCurrencyData : ReadonlyCurrencyData
    {
        public void SetId(CurrencyType value)
        {
            Id = value;
        }

        public void SetAmount(int value)
        {
            Amount = value;

            OnAmountChanged?.Invoke(Amount);
        }

        public void CopyFrom(MutableCurrencyData otherData)
        {
            SetId(otherData.Id);
            SetAmount(otherData.Amount);
        }
    }
}