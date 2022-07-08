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


        private void FixedUpdate()
        {
            if (!(Vector3.SqrMagnitude(_joystick.Direction - _lastJoystickPos) > Epsilon)) return;
            _lastJoystickPos = _joystick.Direction;

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