using Game.Movement;
using Game.Movement.States;
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

        protected virtual void Start()
        {
            base.Start();
            SignalBus.Subscribe<PlayerChangeJoystickSignal>(HandlePlayerMovement);

            _currentState = new MovementMoveState(this);
            _currentState.EnterState();
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