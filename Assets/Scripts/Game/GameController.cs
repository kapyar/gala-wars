using System.Collections;
using System.Collections.Generic;
using Game.Enemy;
using GameConfig;
using GameState.Level;
using GameState.Prefabs;
using GameState.Ships;
using Player;
using UI.EnterNameController.Signals;
using UI.WelcomeScreen.Signals;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject _enemySpawnPoint;
        [SerializeField] private GameObject _playerStartPoint;

        private SignalBus _signalBus;
        private PlayerStateController _playerStateController;
        private PrefabsFactory _prefabsFactory;
        private GameStateController _gameStateController;

        private int _currentLevel;
        private List<LevelDto> _levelDtos = new List<LevelDto>();


        [Inject]
        public void Construct(SignalBus signalBus, PlayerStateController playerStateController,
            PrefabsFactory prefabsFactory, GameStateController gameStateController)
        {
            _signalBus = signalBus;
            _playerStateController = playerStateController;
            _prefabsFactory = prefabsFactory;
            _gameStateController = gameStateController;
        }


        private void Start()
        {
            _signalBus.Subscribe<ContinueGameSignal>(ContinueGame);
            _signalBus.Subscribe<SubmitNameSignal>(StartNewGame);

            _levelDtos = _gameStateController.GameStateDto.LevelDto;

            _signalBus.Fire<StartGameSignal>();
        }

        private void StartNewGame(SubmitNameSignal signal)
        {
            SpawnPlayer();
            StartCoroutine(LoadLevelRoutine(_levelDtos[0]));
        }

        private void ContinueGame(ContinueGameSignal signal)
        {
            Debug.Log("Start quick game");

            SpawnPlayer();
            StartCoroutine(LoadLevelRoutine(_levelDtos[0]));
        }

        public void SpawnPlayer()
        {
            var player = _prefabsFactory.GetShip(_playerStateController.PlayerData.ShipId);

            Instantiate(player, _playerStartPoint.transform);
        }

        private void SpawnEnemy(EnemyShipDto dto)
        {
            var enemy = _prefabsFactory.GetShip(dto.Id);

            var controller = enemy.GetComponent<EnemyController>();
            controller.FromDto(dto);

            Instantiate(enemy, _enemySpawnPoint.transform);
        }

        public IEnumerator LoadLevelRoutine(LevelDto levelDto)
        {
            Debug.Log("LoadLevelRoutine");

            foreach (var wave in levelDto.WaveDto)
            {
                var enemyDto = _gameStateController.GetEnemyShipConfig(wave.EnemyShip);
                SpawnEnemy(enemyDto);

                yield return new WaitForSeconds(wave.Delay);
            }
        }
    }
}