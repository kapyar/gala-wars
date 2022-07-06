using System;
using System.Linq;
using Currency;
using Player;
using Player.Boosters.Signals;
using TMPro;
using UnityEngine;
using Utils;
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
            UIUtils.AnimateLabelWithNumber(_experienceAmount, signal.Amount);
        }

        private void HandleCoins(PlayerEarnCurrencySignal signal)
        {
            UIUtils.AnimateLabelWithNumber(_coinsAmount, signal.Amount);
        }
    }
}