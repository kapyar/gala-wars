using System;

namespace Currency
{
    [Serializable]
    public class CurrencyDto
    {
        protected CurrencyType _type;
        protected int _amount;
    }
}