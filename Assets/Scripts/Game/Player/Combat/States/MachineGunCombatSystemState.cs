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
            throw new System.NotImplementedException();
        }


        public MachineGunCombatSystemState(PlayerCombatSystemContext context) : base(context)
        {
        }
    }
}