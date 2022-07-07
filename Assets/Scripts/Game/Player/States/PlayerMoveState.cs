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
                Mathf.Clamp(context.Rigidbody.position.x, context.Bounds.xMin, context.Bounds.xMax),
                Mathf.Clamp(context.Rigidbody.position.y, context.Bounds.yMin, context.Bounds.yMax),
                0
            );

            context.Rigidbody.rotation = Quaternion.Euler(-90, 0, context.Rigidbody.velocity.x * -context.TiltFactor);
        }
    }
}