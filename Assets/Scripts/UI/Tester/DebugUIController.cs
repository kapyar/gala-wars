using Game.Controllers;
using GameConfig;
using Player;
using PlayerState.Signals;
using UI.EnterNameController.Signals;
using UI.GameOverController.Signals;
using UnityEngine;
using Zenject;

namespace UI.Tester
{
    public class DebugUIController : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private PlayerStateController _playerStateController;
        [Inject] private GameStateController _gameStateController;

        private GameController _gameController;

        private void Start()
        {
            _gameController = FindObjectOfType<GameController>();
        }

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

        public void SpawnPlayer()
        {
            _gameController.SpawnPlayer(_gameStateController.GetPlayerShipConfig());
        }

        public void OpenGameOverScreen()
        {
            _signalBus.Fire<OpenGameOverWindowSignal>();
        }
    }
}