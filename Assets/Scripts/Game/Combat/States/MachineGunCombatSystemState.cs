using Game.Player;
using GameState;
using GameState.Combat;

namespace Game.Combat.States
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


        public MachineGunCombatSystemState(AbstractCombatSystem context) : base(context)
        {
        }
    }
}