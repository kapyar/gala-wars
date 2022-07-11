using System.Collections;
using System.Collections.Generic;
using Game.Controllers.Level.Signals;
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

namespace Game.Controllers
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
            _signalBus.Subscribe<LevelEndedSignal>(OnLevelEnded);

            _levelDtos = _gameStateController.GameStateDto.LevelDto;

            _signalBus.Fire<StartGameSignal>();
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

        private void StartNewGame(SubmitNameSignal signal)
        {
            SpawnPlayer();
            StartCoroutine(LoadLevelRoutine(_levelDtos[0]));
        }

        private void ContinueGame(ContinueGameSignal signal)
        {
            Debug.Log("Start quick game");

            SpawnPlayer();
            StartCoroutine(LoadLevelRoutine(_levelDtos[_currentLevel]));
        }

        private void OnLevelEnded(LevelEndedSignal signal)
        {
            _currentLevel++;

            if (_currentLevel >= _levelDtos.Count)
            {
                _signalBus.Fire<GameLevelsCompleted>();
            }
        }

        private IEnumerator LoadLevelRoutine(LevelDto levelDto)
        {
            Debug.Log("LoadLevelRoutine");

            var levelStartedSignal = new LevelStartedSignal
            {
                Id = levelDto.Name
            };

            _signalBus.Fire(levelStartedSignal);

            foreach (var wave in levelDto.WaveDto)
            {
                _signalBus.Fire<WaveStartedSignal>();

                var enemyDto = _gameStateController.GetEnemyShipConfig(wave.EnemyShip);
                SpawnEnemy(enemyDto);

                yield return new WaitForSeconds(wave.Delay);

                _signalBus.Fire<WaveEndedSignal>();
            }

            var levelEndedSignal = new LevelEndedSignal
            {
                Id = levelDto.Name
            };

            _signalBus.Fire(levelEndedSignal);
        }
    }
}