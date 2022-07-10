using GameState.Level;
using GameState.Prefabs;
using Player;
using UI.EnterNameController.Signals;
using UI.WelcomeScreen.Signals;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject _playerStartPoint;

        private SignalBus _signalBus;
        private PlayerStateController _playerStateController;
        private PrefabsFactory _prefabsFactory;

        private int _currentLevel;


        [Inject]
        public void Construct(SignalBus signalBus, PlayerStateController playerStateController, PrefabsFactory prefabsFactory)
        {
            _signalBus = signalBus;
            _playerStateController = playerStateController;
            _prefabsFactory = prefabsFactory;
        }


        private void Start()
        {
            _signalBus.Subscribe<ContinueGameSignal>(ContinueGame);
            _signalBus.Subscribe<SubmitNameSignal>(StartNewGame);

            _signalBus.Fire<StartGameSignal>();
        }

        private void StartNewGame(SubmitNameSignal signal)
        {
        }

        private void ContinueGame(ContinueGameSignal signal)
        {
            Debug.Log("Start quick game");
            SpawnPlayer();
        }

        public void SpawnPlayer()
        {
            var player = _prefabsFactory.GetShip(_playerStateController.PlayerData.ShipId);

            Instantiate(player, _playerStartPoint.transform);
        }

        public void LoadLevel(LevelDto levelDto)
        {
        }
    }
}