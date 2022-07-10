using GameState.Level;
using GameState.Prefabs;
using Player;
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


        [Inject]
        public void Construct(SignalBus signalBus, PlayerStateController playerStateController, PrefabsFactory prefabsFactory)
        {
            _signalBus = signalBus;
            _playerStateController = playerStateController;
            _prefabsFactory = prefabsFactory;
        }

        public void SpawnPlayer()
        {
            var player = _prefabsFactory.GetShip(_playerStateController.PlayerData.ShipId);

            Instantiate(player, _playerStartPoint.transform);
        }

        public void LoadWave(WaveDto dto)
        {
        }
    }
}