using Game.Player.States;
using GameConfig;
using PlayerInput.Signals;
using UnityEngine;
using Zenject;
using Bounds = PlayerInput.Bounds;

namespace Game.Player
{
    public class PlayerContext : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        public Rigidbody Rigidbody => _rigidbody;

        [SerializeField] private MeshRenderer _meshRenderer;

        public Bounds Bounds { get; private set; }

        [SerializeField] private float _tiltFactor;
        public float TiltFactor => _tiltFactor;

        private PlayerBaseState _currentState;
        private StartPositionState _startPositionState;

        [Inject] private SignalBus _signalBus;
        [Inject] private GameStateDto _gameStateDto;

        public GameStateDto GameStateDto => _gameStateDto;

        public Vector2 Direction { get; private set; }

        private void Start()
        {
            Bounds = new Bounds(Camera.main, _meshRenderer);

            _signalBus.Subscribe<PlayerChangeJoystickSignal>(HandlePlayerMovement);

            _currentState = new PlayerMoveState();
            _currentState.EnterState(this);
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