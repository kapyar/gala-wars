using System;
using System.Linq;
using Currency;
using DG.Tweening;
using Player;
using Player.Boosters.Signals;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.Top
{
    public class TopUIController : MonoBehaviour
    {
        private const float CoinsSpeed = 10;

        [SerializeField] private BoosterUIController _boosterUIController;
        [SerializeField] private TextMeshProUGUI _coinsAmount;
        [SerializeField] private TextMeshProUGUI _experienceAmount;

        [Inject] private SignalBus _signalBus;
        [Inject] private PlayerStateController _playerStateController;

        private void Start()
        {
            _coinsAmount.text = _playerStateController.PlayerData.Bank
                .FirstOrDefault(x => x.Id == CurrencyType.Coins)?.Amount.ToString();

            _experienceAmount.text = _playerStateController.PlayerData.Bank
                .FirstOrDefault(x => x.Id == CurrencyType.Experience)?.Amount.ToString();

            _signalBus.Subscribe<PlayerEarnCurrencySignal>(OnPlayerBalanceChanged);
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<PlayerEarnCurrencySignal>(OnPlayerBalanceChanged);
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
            DOTween.To(() => double.Parse(_experienceAmount.text),
                x => { _experienceAmount.text = x.ToString("N0"); },
                signal.Amount, GetCoinTweenDuration(0, signal.Amount)
            );
        }

        private void HandleCoins(PlayerEarnCurrencySignal signal)
        {
            DOTween.To(() => double.Parse(_coinsAmount.text),
                x => { _coinsAmount.text = x.ToString("N0"); },
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