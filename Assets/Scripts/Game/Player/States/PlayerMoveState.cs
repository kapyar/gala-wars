using UnityEngine;

namespace Game.Player.States
{
    public class PlayerMoveState : PlayerBaseState
    {
        public override void EnterState(PlayerContext context)
        {
        }

        public override void Update(PlayerContext context)
        {
            var direction = Vector3.up * context.Direction.y + Vector3.right * context.Direction.x;

            context.Rigidbody.velocity = direction * context.GameStateDto.PlayerShipsDto.Speed;

            context.Rigidbody.position = new Vector3(
                Mathf.Clamp(context.Rigidbody.position.x, context.Boundary.xMin, context.Boundary.xMax),
                Mathf.Clamp(context.Rigidbody.position.y, context.Boundary.yMin, context.Boundary.yMax),
                0
            );

            context.Rigidbody.rotation = Quaternion.Euler(-90, 0, context.Rigidbody.velocity.x * -context.TiltFactor);
        }
    }
}