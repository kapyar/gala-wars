using GameState;

namespace Game.Player.Combat.States
{
    public class StartPlayerCombatSystemState : BaseCombatSystemState
    {
        protected override CombatSystemType GetCombatSystemType()
        {
            return CombatSystemType.StartPlayer;
        }

        protected override void Shoot()
        {
            var pos = _context.GunHolder.Cannon;
            SpawnAtPos(pos);
        }

        public StartPlayerCombatSystemState(PlayerCombatSystemContext context) : base(context)
        {
        }
    }
}