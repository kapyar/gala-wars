using System;
using System.Globalization;
using Currency;
using DG.Tweening;
using Player.Boosters.Signals;
using UI.Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Top
{
    public class TopUIController : UIController
    {
        [SerializeField] private BoosterUIController _boosterUIController;

        [SerializeField] private Text _coinsAmount;
        [SerializeField] private Text _experienceAmount;

        private const float CoinsSpeed = 10;

        private void Start()
        {
            _signalBus.Subscribe<PlayerEarnCurrencySignal>(OnPlayerBalanceChanged);
        }

        private void OnPlayerBalanceChanged(PlayerEarnCurrencySignal signal)
        {
            switch (signal.Type)
            {
                case CurrencyType.Coins:
                    HandleCoins(signal);
                    break;
                case CurrencyType.Experience:
                    HandleExperience(signal);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void HandleExperience(PlayerEarnCurrencySignal signal)
        {
            throw new NotImplementedException();
        }

        private void HandleCoins(PlayerEarnCurrencySignal signal)
        {
            DOTween.To(() => double.Parse(_coinsAmount.text),
                x => { _coinsAmount.text = x.ToString(CultureInfo.InvariantCulture); },
                signal.Amount, GetCoinTweenDuration(0, signal.Amount)
            );
        }

        private float GetCoinTweenDuration(int from, int to)
        {
            var duration = Mathf.Abs(to - from) / CoinsSpeed;
            duration = Mathf.Clamp01(duration);
            return duration;
        }
    }
}