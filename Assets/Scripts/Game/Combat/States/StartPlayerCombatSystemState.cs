using GameState;
using GameState.Combat;

namespace Game.Combat.States
{
    public class StartPlayerCombatSystemState : BaseCombatSystemState
    {
        protected override CombatSystemType GetCombatSystemType()
        {
            return CombatSystemType.StartPlayer;
        }

        protected override void Shoot()
        {
            SpawnAtPos(_context.GunHolder.Cannon);
        }

        public StartPlayerCombatSystemState(AbstractCombatSystem context) : base(context)
        {
        }
    }
}