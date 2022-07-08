using GameState;
using UnityEngine;

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
            Debug.Log("Shooting start combat system");
        }
    }
}