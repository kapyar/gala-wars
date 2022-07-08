using Game.Player.Combat.States;
using GameConfig;
using GameState.Prefabs;
using Player;
using PlayerInput.Signals;
using UnityEngine;
using Zenject;

namespace Game.Player.Combat
{
    public class PlayerCombatSystemContext : MonoBehaviour
    {
        [SerializeField] private GunHolder _gunHolder;
        public GunHolder GunHolder => _gunHolder;


        private SignalBus _signalBus;
        public PlayerStateController PlayerStateController { get; private set; }
        public GameStateController GameStateController { get; private set; }
        public PrefabsFactory PrefabsFactory { get; private set; }

        private BaseCombatSystemState _currentState;

        [Inject]
        public void Construct(SignalBus signalBus, PlayerStateController playerStateController,
            GameStateController gameStateController, PrefabsFactory prefabsFactory)
        {
            _signalBus = signalBus;
            PlayerStateController = playerStateController;
            GameStateController = gameStateController;
            PrefabsFactory = prefabsFactory;
        }

        private void Start()
        {
            _signalBus.Subscribe<PlayerPressShootBtnSignal>(OnPlayerPressShootBtn);

            _currentState = new BombCombatSystemState(this);
        }

        private void Update()
        {
            _currentState.Update();
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<PlayerPressShootBtnSignal>(OnPlayerPressShootBtn);
        }

        private void OnPlayerPressShootBtn(PlayerPressShootBtnSignal signal)
        {
            _currentState.EnterState();
        }
    }
}