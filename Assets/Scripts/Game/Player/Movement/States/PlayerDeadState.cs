using UnityEngine;

namespace Game.Player.Movement.States
{
    public class PlayerDeadState : PlayerBaseState
    {
        public override void EnterState(PlayerContext context)
        {
            Debug.Log("Player Dead");
            //handle player dead
        }

        public override void Update(PlayerContext context)
        {
        }
    }
}