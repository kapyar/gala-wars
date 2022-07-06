using Player;
using Player.Signals;
using TMPro;
using UI.GameOverController.Signals;
using UI.Helpers;
using UnityEngine;
using Utils;
using Zenject;

namespace UI.GameOverController
{
    public class GameOverUIController : UIController
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private PlayerStateController _playerStateController;

        [SerializeField] private TextMeshProUGUI _highestScore;
        [SerializeField] private TextMeshProUGUI _currentScore;

        private void Start()
        {
            _signalBus.Subscribe<OpenGameOverWindowSignal>(Open);
        }

        public override void Open()
        {
            base.Open();

            AnimateHighestScore();
        }

        private void AnimateHighestScore()
        {
            var score = _playerStateController.PlayerData.HighScore;

            UIUtils.AnimateLabelWithNumber(_highestScore, score);
        }


        public void QuitGame()
        {
            _signalBus.Fire<SaveDataSignal>();
            _signalBus.Fire<QuitGameSignal>();
        }
    }
}