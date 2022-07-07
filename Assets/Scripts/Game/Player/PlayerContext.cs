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

        private readonly Boundary _boundary = new Boundary();
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
            var bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            _boundary.xMax = bounds.x;
            _boundary.xMin = -bounds.x;

            _boundary.yMax = bounds.y;
            _boundary.yMin = -bounds.y;

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