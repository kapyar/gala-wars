using Player;
using Player.Signals;
using UI.EnterNameController.Signals;
using UnityEngine;
using Zenject;

namespace UI.Tester
{
    public class DebugUIController : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private PlayerStateController _playerStateController;

        public void AddCoins()
        {
            _playerStateController.AddCoins();
        }

        public void AddExp()
        {
            _playerStateController.AddExp();
        }

        public void OpenEnterName()
        {
            _signalBus.Fire<OpenEnterNameWindowSignal>();
        }

        public void SaveGame()
        {
            _signalBus.Fire<SaveDataSignal>();
        }
    }
}