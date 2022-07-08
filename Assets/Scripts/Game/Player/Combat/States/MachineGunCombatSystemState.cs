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

        public override void EnterState(PlayerCombatSystemContext context)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(PlayerCombatSystemContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}