using Game.Player.States;
using GameConfig;
using PlayerInput;
using PlayerInput.Signals;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerContext : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        public Rigidbody Rigidbody => _rigidbody;

        [SerializeField] private Boundary _boundary;
        public Boundary Boundary => _boundary;

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