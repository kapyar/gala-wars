using DG.Tweening;
using UI.Overlay.Signals;
using UnityEngine;
using Zenject;

namespace UI.Helpers
{
    public abstract class UIController : MonoBehaviour
    {
        [Inject] protected SignalBus _signalBus;
        [SerializeField] protected DOTweenAnimation _animation;

        public virtual void Open()
        {
            _animation.DORestart();
            _signalBus.Fire<OpenUIControllerSignal>();
        }

        public virtual void Close()
        {
            _animation.DOPlayBackwards();
            _signalBus.Fire<CloseUIControllerSignal>();
        }
    }
}