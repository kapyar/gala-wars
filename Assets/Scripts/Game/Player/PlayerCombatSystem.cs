using Game.Combat;
using Game.Combat.States;
using GameConfig;
using GameState.Prefabs;
using Player;
using PlayerInput.Signals;
using Zenject;

namespace Game.Player
{
    public class PlayerCombatSystem : AbstractCombatSystem
    {
        public PlayerStateController PlayerStateController { get; private set; }

        [Inject]
        public void Construct(SignalBus signalBus, PlayerStateController playerStateController,
            GameStateController gameStateController, PrefabsFactory prefabsFactory)
        {
            base.Construct(signalBus, gameStateController, prefabsFactory);

            PlayerStateController = playerStateController;
        }

        private void Start()
        {
            SignalBus.Subscribe<PlayerPressShootBtnSignal>(OnPlayerPressShootBtn);

            _currentState = new StartPlayerCombatSystemState(this);
        }

        private void OnDestroy()
        {
            SignalBus.Unsubscribe<PlayerPressShootBtnSignal>(OnPlayerPressShootBtn);
        }

        private void OnPlayerPressShootBtn(PlayerPressShootBtnSignal signal)
        {
            _currentState.EnterState();
        }
    }
}