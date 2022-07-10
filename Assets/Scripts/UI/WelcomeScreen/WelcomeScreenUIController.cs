using Game;
using Player;
using TMPro;
using UI.EnterNameController.Signals;
using UI.Helpers;
using UI.WelcomeScreen.Signals;
using UnityEngine;
using Utils;
using Zenject;

namespace UI.WelcomeScreen
{
    public class WelcomeScreenUIController : UIController
    {
        [SerializeField] private TextMeshProUGUI _highestScore;
        [SerializeField] private TextMeshProUGUI _name;

        private SignalBus _signalBus;
        private PlayerStateController _playerStateController;

        [Inject]
        public void Construct(SignalBus signalBus, PlayerStateController playerStateController)
        {
            _signalBus = signalBus;
            _playerStateController = playerStateController;
        }

        private void Start()
        {
            _signalBus.Subscribe<StartGameSignal>(Open);
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<StartGameSignal>(Open);
        }

        public override void Open()
        {
            base.Open();
            _name.text = _playerStateController.PlayerData.Name;
            
            AnimateHighestScore();
        }


        public void OnNewGame()
        {
            Close();

            _signalBus.Fire<OpenEnterNameWindowSignal>();
        }

        public void OnContinue()
        {
            Close();

            _signalBus.Fire<ContinueGameSignal>();
        }

        private void AnimateHighestScore()
        {
            var score = _playerStateController.PlayerData.HighScore;

            UIUtils.AnimateLabelWithNumber(_highestScore, score);
        }
    }
}