using UI.Overlay.Signals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Overlay
{
    public class OverlayUIController : MonoBehaviour
    {
        [SerializeField] private Image _overlay;

        [Inject] private SignalBus _signalBus;

        private int _counter;

        private void Start()
        {
            _signalBus.Subscribe<OpenUIControllerSignal>(OnOpenUIController);
            _signalBus.Subscribe<CloseUIControllerSignal>(OnCloseUIController);
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<OpenUIControllerSignal>(OnOpenUIController);
            _signalBus.Unsubscribe<CloseUIControllerSignal>(OnCloseUIController);
        }

        private void OnOpenUIController(OpenUIControllerSignal signal)
        {
            Debug.Log("OnOpenUIController");
            if (_counter == 0)
            {
                _overlay.enabled = true;
            }

            _counter++;
        }

        private void OnCloseUIController(CloseUIControllerSignal signal)
        {
            Debug.Log("OnCloseUIController");
            if (_counter == 1)
            {
                _overlay.enabled = false;
            }

            _counter--;
        }
    }
}