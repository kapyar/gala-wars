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
            SpawnAtPos(_context.GunHolder.Cannon);
        }

        public StartPlayerCombatSystemState(PlayerCombatSystemContext context) : base(context)
        {
        }
    }
}