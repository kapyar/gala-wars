using Game.Player.Movement.States;
using GameConfig;
using Player;
using PlayerInput.Signals;
using UnityEngine;
using Zenject;
using Bounds = PlayerInput.Bounds;

namespace Game.Player.Movement
{
    public class PlayerContext : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        public Rigidbody Rigidbody => _rigidbody;

        [SerializeField] private MeshRenderer _meshRenderer;

        [SerializeField] private float _tiltFactor;
        public float TiltFactor => _tiltFactor;

        private PlayerBaseState _currentState;
        private StartPositionState _startPositionState;

        public SignalBus SignalBus { get; private set; }

        private PlayerStateController PlayerStateController { get; set; }

        public GameStateController GameStateController { get; private set; }

        public Bounds Bounds { get; private set; }
        public Vector2 Direction { get; private set; }


        [Inject]
        public void Construct(SignalBus signalBus, GameStateController gameStateController, PlayerStateController playerStateController)
        {
            SignalBus = signalBus;
            GameStateController = gameStateController;
            PlayerStateController = playerStateController;
        }

        private void Start()
        {
            Bounds = new Bounds(Camera.main, _meshRenderer);

            SignalBus.Subscribe<PlayerChangeJoystickSignal>(HandlePlayerMovement);

            _currentState = new PlayerMoveState();
            _currentState.EnterState(this);
        }

        private void OnDestroy()
        {
            SignalBus.Unsubscribe<PlayerChangeJoystickSignal>(HandlePlayerMovement);
        }

        private void FixedUpdate()
        {
            _currentState.Update(this);
        }

        private void HandlePlayerMovement(PlayerChangeJoystickSignal signal)
        {
            Direction = signal.Direction;
        }
    }
}