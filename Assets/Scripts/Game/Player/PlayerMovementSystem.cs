using Game.Movement;
using Game.Movement.States;
using Game.Player.Signals;
using GameConfig;
using Player;
using PlayerInput.Signals;
using Zenject;

namespace Game.Player
{
    public class PlayerMovementSystem : AbstractMovementSystem
    {
        private PlayerStateController PlayerStateController { get; set; }

        [Inject]
        public void Construct(SignalBus signalBus, GameStateController gameStateController, PlayerStateController playerStateController)
        {
            base.Construct(signalBus, gameStateController);

            PlayerStateController = playerStateController;
        }

        public override string GetName()
        {
            return "Player";
        }

        protected virtual void Start()
        {
            base.Start();
            SignalBus.Subscribe<PlayerChangeJoystickSignal>(HandlePlayerMovement);
            SignalBus.Subscribe<PlayerDiedSignal>(OnPlayerDied);

            _currentState = new MovementMoveState(this);
            _currentState.EnterState();
        }

        private void OnPlayerDied(PlayerDiedSignal obj)
        {
            _currentState = new MovementDeadState(this);
        }


        private void OnDestroy()
        {
            SignalBus.Unsubscribe<PlayerChangeJoystickSignal>(HandlePlayerMovement);
        }

        private void HandlePlayerMovement(PlayerChangeJoystickSignal signal)
        {
            Direction = signal.Direction;
        }
    }
}