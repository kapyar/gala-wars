using Game.Combat;
using Game.Combat.States;
using GameConfig;
using GameState.Prefabs;
using Zenject;

namespace Game.Enemy
{
    public class EnemyCombatSystem : AbstractCombatSystem
    {
        [Inject]
        public void Construct(SignalBus signalBus, GameStateController gameStateController, PrefabsFactory prefabsFactory)
        {
            base.Construct(signalBus, gameStateController, prefabsFactory);
        }

        private void Start()
        {
            _currentState = new BombCombatSystemState(this);
        }

        protected virtual void Update()
        {
            base.Update();
            _currentState.EnterState();
        }
    }
}