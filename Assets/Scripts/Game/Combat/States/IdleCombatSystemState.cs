using GameState.Combat;

namespace Game.Combat.States
{
    public class IdleCombatSystemState : BaseCombatSystemState
    {
        public IdleCombatSystemState(AbstractCombatSystem context) : base(context)
        {
        }

        protected override CombatSystemType GetCombatSystemType()
        {
            return CombatSystemType.Idle;
        }

        protected override void Shoot()
        {
        }
    }
}