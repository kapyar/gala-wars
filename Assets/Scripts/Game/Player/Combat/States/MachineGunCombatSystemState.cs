using GameState;

namespace Game.Player.Combat.States
{
    public class MachineGunCombatSystemState : BaseCombatSystemState
    {
        protected override CombatSystemType GetCombatSystemType()
        {
            return CombatSystemType.MachineGun;
        }

        protected override void Shoot()
        {
            SpawnAtPos(_context.GunHolder.Left);
            SpawnAtPos(_context.GunHolder.Right);
        }


        public MachineGunCombatSystemState(PlayerCombatSystemContext context) : base(context)
        {
        }
    }
}