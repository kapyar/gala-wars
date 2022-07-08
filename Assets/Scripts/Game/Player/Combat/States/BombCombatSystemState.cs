using GameState;

namespace Game.Player.Combat.States
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

        public BombCombatSystemState(PlayerCombatSystemContext context) : base(context)
        {
        }
    }
}