using Currency;
using Player.Boosters.Signals;
using UnityEngine;
using Zenject;

namespace UI.Tester
{
    public class DebugUIController : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;

        public void AddCoins()
        {
            var signal = new PlayerEarnCurrencySignal
            {
                Type = CurrencyType.Coins,
                Amount = 100
            };
        }
    }
}