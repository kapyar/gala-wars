using System;
using Game.Combat.Bullet;
using Game.Combat.States;
using GameConfig;
using GameState.Combat;
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

        public void SetState(CombatSystemType type)
        {
            switch (type)
            {
                case CombatSystemType.Enemy:
                    break;
                case CombatSystemType.StartPlayer:
                    _currentState = new StartPlayerCombatSystemState(this);
                    break;
                case CombatSystemType.Bomb:
                    _currentState = new BombCombatSystemState(this);
                    break;
                case CombatSystemType.MachineGun:
                    _currentState = new MachineGunCombatSystemState(this);
                    break;
                case CombatSystemType.Idle:
                    _currentState = new IdleCombatSystemState(this);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}