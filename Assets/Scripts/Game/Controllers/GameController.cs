using System.Collections;
using System.Collections.Generic;
using Game.Controllers.Level.Signals;
using Game.Enemy;
using Game.Player;
using Game.Player.Signals;
using GameConfig;
using GameState.Level;
using GameState.Prefabs;
using GameState.Ships;
using Player;
using UI.EnterNameController.Signals;
using UI.GameOverController.Signals;
using UI.VictoryController.Signals;
using UI.WelcomeScreen.Signals;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _enemySpawnPoint;
        [SerializeField] private GameObject _playerStartPoint;

        private SignalBus _signalBus;
        private PlayerStateController _playerStateController;
        private PrefabsFactory _prefabsFactory;
        private GameStateController _gameStateController;

        private int _currentLevel;
        private List<LevelDto> _levelDtos = new List<LevelDto>();

        private Coroutine _loadLevelRoutine;

        private List<GameObject> _spawnedEnemies = new List<GameObject>();
        private GameObject _player;


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
            _signalBus.Subscribe<PlayerDiedSignal>(OnPlayerDied);
            _signalBus.Subscribe<QuitGameSignal>(OnQuitGame);
            _signalBus.Subscribe<StartGameAfterCompleteSignal>(OnStartGameAfterComplete);

            _levelDtos = _gameStateController.GameStateDto.LevelDto;

            _signalBus.Fire<StartGameSignal>();
        }

        private void OnStartGameAfterComplete(StartGameAfterCompleteSignal obj)
        {
            Destroy(_player);
            _currentLevel = 0;

            _signalBus.Fire<StartGameSignal>();
        }

        private void OnQuitGame(QuitGameSignal obj)
        {
            DestroyRemainingEnemies();
            _signalBus.Fire<StartGameSignal>();
        }


        public void SpawnPlayer(ShipDto dto)
        {
            var player = _prefabsFactory.GetShip(_playerStateController.PlayerData.ShipId);

            var controller = player.GetComponent<PlayerController>();
            controller.FromDto(dto);

            _player = Instantiate(player, _playerStartPoint.transform);
        }

        private void SpawnEnemy(EnemyShipDto dto)
        {
            var enemy = _prefabsFactory.GetShip(dto.Id);

            var controller = enemy.GetComponent<EnemyController>();
            controller.FromDto(dto);

            var enemyGo = Instantiate(enemy, _enemySpawnPoint[Random.Range(0, _enemySpawnPoint.Count)].transform);

            _spawnedEnemies.Add(enemyGo);
        }

        private void StartNewGame(SubmitNameSignal signal)
        {
            SpawnPlayer(_gameStateController.GetPlayerShipConfig());

            _loadLevelRoutine = StartCoroutine(LoadLevelRoutine(_levelDtos[0]));
        }

        private void ContinueGame(ContinueGameSignal signal)
        {
            Debug.Log("Start quick game");

            SpawnPlayer(_gameStateController.GetPlayerShipConfig());
            _loadLevelRoutine = StartCoroutine(LoadLevelRoutine(_levelDtos[_currentLevel]));
        }

        private void OnLevelEnded(LevelEndedSignal signal)
        {
            _currentLevel++;

            if (_currentLevel >= _levelDtos.Count)
            {
                _signalBus.Fire<GameLevelsCompleted>();
            }
            else
            {
                _loadLevelRoutine = StartCoroutine(LoadLevelRoutine(_levelDtos[_currentLevel]));
            }
        }

        private void OnPlayerDied(PlayerDiedSignal obj)
        {
            StopCoroutine(_loadLevelRoutine);
        }

        private void DestroyRemainingEnemies()
        {
            foreach (var enemy in _spawnedEnemies)
            {
                if (enemy != null)
                {
                    Destroy(enemy);
                }
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

                foreach (var waveWaveEnemyDto in wave.WaveEnemyDtos)
                {
                    var enemyDto = _gameStateController.GetEnemyShipConfig(waveWaveEnemyDto.EnemyShip);

                    SpawnEnemy(enemyDto);

                    yield return new WaitForSeconds(waveWaveEnemyDto.Delay);
                }

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