using System;
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
            throw new NotImplementedException();
        }

        public override void EnterState(PlayerCombatSystemContext context)
        {
            throw new NotImplementedException();
        }

        public override void Update(PlayerCombatSystemContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}