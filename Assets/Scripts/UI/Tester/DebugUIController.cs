using Player;
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
    }
}