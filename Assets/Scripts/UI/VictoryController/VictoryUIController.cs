using Game;
using Game.Controllers;
using Game.Controllers.Level.Signals;
using Player;
using TMPro;
using UI.Helpers;
using UI.VictoryController.Signals;
using UnityEngine;
using Utils;
using Zenject;

namespace UI.VictoryController
{
    public class VictoryUIController : UIController
    {
        [SerializeField] private TextMeshProUGUI _finalScore;
        [Inject] private PlayerStateController _playerStateController;

        private void Start()
        {
            _signalBus.Subscribe<GameLevelsCompleted>(OnAllLevelsCompleted);
        }

        private void OnAllLevelsCompleted(GameLevelsCompleted signal)
        {
            Open();
        }

        public override void Open()
        {
            base.Open();
            UIUtils.AnimateLabelWithNumber(_finalScore, _playerStateController.PlayerData.HighScore);
        }

        public void OnRestart()
        {
            Close();
            _signalBus.Fire<StartGameAfterCompleteSignal>();
        }

        public void OnExit()
        {
            Close();
            Application.Quit();
        }
    }
}