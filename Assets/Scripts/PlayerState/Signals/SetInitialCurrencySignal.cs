using Currency;

namespace PlayerState.Signals
{
    public class SetInitialCurrencySignal
    {
        public CurrencyType Type;
        public int Amount;
    }
}