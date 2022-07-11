using Game.Combat.Bullet;
using Game.Combat.States;
using GameConfig;
using GameState.Prefabs;
using UnityEngine;
using Zenject;

namespace Game.Combat
{
    public abstract class AbstractCombatSystem : MonoBehaviour
    {
        [SerializeField] private GunHolder _gunHolder;
        public GunHolder GunHolder => _gunHolder;
        public SignalBus SignalBus { get; protected set; }

        public GameStateController GameStateController { get; protected set; }
        public PrefabsFactory PrefabsFactory { get; protected set; }

        protected BaseCombatSystemState _currentState;

        public BulletOwner BulletOwner { get; protected set; }

        protected void Construct(SignalBus signalBus,
            GameStateController gameStateController, PrefabsFactory prefabsFactory)
        {
            SignalBus = signalBus;
            GameStateController = gameStateController;
            PrefabsFactory = prefabsFactory;
        }

        protected virtual void Update()
        {
            _currentState.Update();
        }
    }
}