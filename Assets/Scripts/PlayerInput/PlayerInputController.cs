using PlayerInput.Signals;
using UnityEngine;
using Zenject;

namespace PlayerInput
{
    public class PlayerInputController : MonoBehaviour
    {
        private const float Epsilon = 0.1f;

        [SerializeField] private Joystick _joystick;

        [Inject] private SignalBus _signalBus;

        private Vector2 _lastJoystickPos;
        private Vector2 _movement;

        [SerializeField] private bool IsKeyboard;

        private void FixedUpdate()
        {
            if (IsKeyboard)
            {
                _lastJoystickPos = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
            else
            {
                if (!(Vector2.SqrMagnitude(_joystick.Direction - _lastJoystickPos) > Epsilon)) return;

                _lastJoystickPos = _joystick.Direction;
            }

            OnMovement();
        }

        private void OnMovement()
        {
            var signal = new PlayerChangeJoystickSignal
            {
                Direction = _lastJoystickPos
            };

            _signalBus.Fire(signal);
        }

        public void OnPressShootButton()
        {
            _signalBus.Fire<PlayerPressShootBtnSignal>();
        }
    }
}