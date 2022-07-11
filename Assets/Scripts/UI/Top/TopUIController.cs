using System;
using System.Linq;
using Currency;
using DG.Tweening;
using Game.Controllers.Level.Signals;
using Player;
using PlayerState.Boosters.Signals;
using TMPro;
using UnityEngine;
using Utils;
using Zenject;

namespace UI.Top
{
    public class TopUIController : MonoBehaviour
    {
        [SerializeField] private BoosterUIController _boosterUIController;
        [SerializeField] private TextMeshProUGUI _coinsAmount;
        [SerializeField] private TextMeshProUGUI _experienceAmount;
        [SerializeField] private TextMeshProUGUI _levelAnouncement;

        [Inject] private SignalBus _signalBus;
        [Inject] private PlayerStateController _playerStateController;

        private void Start()
        {
            _coinsAmount.text = _playerStateController.PlayerData.Bank
                .FirstOrDefault(x => x.Id == CurrencyType.Coins)?.Amount.ToString();

            _experienceAmount.text = _playerStateController.PlayerData.Bank
                .FirstOrDefault(x => x.Id == CurrencyType.Experience)?.Amount.ToString();

            _signalBus.Subscribe<PlayerEarnCurrencySignal>(OnPlayerBalanceChanged);
            _signalBus.Subscribe<WaveStartedSignal>(OnNewWaveStarted);
            _signalBus.Subscribe<LevelStartedSignal>(OnNewLevelStarted);
        }

        private void OnNewWaveStarted(WaveStartedSignal signal)
        {
        }

        private void OnNewLevelStarted(LevelStartedSignal signal)
        {
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