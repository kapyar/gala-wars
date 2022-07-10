using GameState;
using GameState.Combat;

namespace Game.Combat.States
{
    public class BombCombatSystemState : BaseCombatSystemState
    {
        protected override CombatSystemType GetCombatSystemType()
        {
            return CombatSystemType.Bomb;
        }

        protected override void Shoot()
        {
            SpawnAtPos(_context.GunHolder.Cannon);
        }

        public BombCombatSystemState(AbstractCombatSystem context) : base(context)
        {
        }
    }
}