using System;
using UnityEngine;

namespace Game.Movement.States
{
    public class MovementDeadState : MovementBaseState
    {
        public MovementDeadState(AbstractMovementSystem context) : base(context)
        {
        }

        public override void EnterState()
        {
            Debug.Log("Player Dead");
        }

        public override void FixedUpdate()
        {
            throw new NotImplementedException();
        }
    }
}