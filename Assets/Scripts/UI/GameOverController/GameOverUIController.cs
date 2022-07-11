using Game.Controllers.Leaderboard;
using Player;
using Player.Signals;
using UI.GameOverController.Signals;
using UI.Helpers;
using UnityEngine;
using Zenject;

namespace UI.GameOverController
{
    public class GameOverUIController : UIController
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private PlayerStateController _playerStateController;
        [Inject] private LeaderboardController _leaderboardController;

        [SerializeField] private RecordEntryUI _allTime;
        [SerializeField] private RecordEntryUI _yourBest;
        [SerializeField] private RecordEntryUI _yourCurrent;

        private void Start()
        {
            _signalBus.Subscribe<OpenGameOverWindowSignal>(Open);
        }

        public override void Open()
        {
            base.Open();

            _allTime.SetValues(_leaderboardController.Data.Name, _leaderboardController.Data.Score);
            _yourBest.SetValues(_playerStateController.PlayerData.Name, _playerStateController.PlayerData.HighScore);
            _yourCurrent.SetValues(_playerStateController.PlayerData.Name, _playerStateController.ExperienceBank.Amount);
        }


        public void ContinueGame()
        {
        }

        public void QuitGame()
        {
            _signalBus.Fire<SaveDataSignal>();
            _signalBus.Fire<QuitGameSignal>();
        }
    }
}