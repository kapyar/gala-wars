using Game.Movement.States;
using GameConfig;
using UnityEngine;
using Zenject;

namespace Game.Movement
{
    public class AbstractMovementSystem : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        public Rigidbody Rigidbody => _rigidbody;

        [SerializeField] protected MeshRenderer _meshRenderer;
        [SerializeField] private float _tiltFactor;

        public GameStateController GameStateController { get; protected set; }
        public float TiltFactor => _tiltFactor;
        protected MovementBaseState _currentState;
        public SignalBus SignalBus { get; protected set; }

        public Bounds Bounds { get; protected set; }
        public Vector2 Direction { get; protected set; }


        protected void Construct(SignalBus signalBus, GameStateController gameStateController)
        {
            SignalBus = signalBus;
            GameStateController = gameStateController;
        }

        protected virtual void Start()
        {
            Bounds = new Bounds(Camera.main, _meshRenderer);
        }
    }
}