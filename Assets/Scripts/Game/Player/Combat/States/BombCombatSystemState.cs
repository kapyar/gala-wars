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

        public BombCombatSystemState(PlayerCombatSystemContext context) : base(context)
        {
        }
    }
}