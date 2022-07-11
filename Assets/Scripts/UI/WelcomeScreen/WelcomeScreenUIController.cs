using Game;
using Game.Controllers.Leaderboard;
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
        private LeaderboardController _leaderboardController;

        [Inject]
        public void Construct(SignalBus signalBus, LeaderboardController leaderboardController)
        {
            _signalBus = signalBus;
            _leaderboardController = leaderboardController;
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
            _name.text = _leaderboardController.Data.Name;

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
            var score = _leaderboardController.Data.Score;

            UIUtils.AnimateLabelWithNumber(_highestScore, score);
        }
    }
}