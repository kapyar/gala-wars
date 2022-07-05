using System;
using Player.Boosters;
using Player.Boosters.Signals;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Zenject;

namespace UI.Top
{
    public class BoosterUIController : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;

        [SerializeField] private Image _machineGun;
        [SerializeField] private Image _cannon;
        [SerializeField] private Image _shield;

        private void Start()
        {
            _signalBus.Subscribe<PlayerEarnBooster>(OnPlayerEarnedBooster);
            _signalBus.Subscribe<BoosterExpiredSignal>(OnPlayerBoosterExpired);
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<PlayerEarnBooster>(OnPlayerEarnedBooster);
            _signalBus.Unsubscribe<BoosterExpiredSignal>(OnPlayerBoosterExpired);
        }

        private void OnPlayerEarnedBooster(PlayerEarnBooster signal)
        {
            ChangeBoosterState(signal.Type, 1f);
        }

        private void OnPlayerBoosterExpired(BoosterExpiredSignal signal)
        {
            ChangeBoosterState(signal.Type, 0.5f);
        }

        private void ChangeBoosterState(BoosterType type, float alpha)
        {
            switch (type)
            {
                case BoosterType.MachineGun:
                    _machineGun.ChangeAlpha(alpha);
                    break;
                case BoosterType.Cannon:
                    _cannon.ChangeAlpha(alpha);
                    break;
                case BoosterType.Shield:
                    _shield.ChangeAlpha(alpha);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}