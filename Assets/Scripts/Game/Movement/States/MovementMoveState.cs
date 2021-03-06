using UnityEngine;

namespace Game.Movement.States
{
    public class MovementMoveState : MovementBaseState
    {
        public MovementMoveState(AbstractMovementSystem context) : base(context)
        {
        }

        public override void EnterState()
        {
        }

        public override void FixedUpdate()
        {
            var direction = Vector3.up * _context.Direction.y + Vector3.right * _context.Direction.x;

            _context.Rigidbody.velocity = direction * _context.GetDto().Speed;

            _context.Rigidbody.position = new Vector3(
                Mathf.Clamp(_context.Rigidbody.position.x, _context.Bounds.xMin, _context.Bounds.xMax),
                Mathf.Clamp(_context.Rigidbody.position.y, _context.Bounds.yMin, _context.Bounds.yMax),
                0
            );

            var x = 90;
            if (_context.GetDto().Id.Equals(_context.PlayerStateController.PlayerData.ShipId))
            {
                x = -x;
            }

            _context.Rigidbody.rotation = Quaternion.Euler(x, 0, _context.Rigidbody.velocity.x * -_context.TiltFactor);
        }
    }
}