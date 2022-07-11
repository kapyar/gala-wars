using Game.Movement.States;
using GameConfig;
using GameState.Ships;
using Player;
using UnityEngine;
using Zenject;

namespace Game.Movement
{
    public abstract class AbstractMovementSystem : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private AbstractShipController _shipController;
        public Rigidbody Rigidbody => _rigidbody;

        [SerializeField] protected MeshRenderer _meshRenderer;
        [SerializeField] private float _tiltFactor;

        public PlayerStateController PlayerStateController { get; protected set; }
        public float TiltFactor => _tiltFactor;
        protected MovementBaseState _currentState;
        public SignalBus SignalBus { get; protected set; }

        public Bounds Bounds { get; protected set; }
        public Vector2 Direction { get; protected set; }

        public ShipDto GetDto()
        {
            return _shipController.GetShipDto();
        }

        protected void Construct(SignalBus signalBus, PlayerStateController playerStateController)
        {
            SignalBus = signalBus;
            PlayerStateController = playerStateController;
        }

        protected virtual void Start()
        {
            Bounds = new Bounds(Camera.main, _meshRenderer);
        }

        protected virtual void FixedUpdate()
        {
            _currentState.FixedUpdate();
        }
    }
}