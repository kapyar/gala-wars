using DG.Tweening;
using UnityEngine;
using Zenject;

namespace UI.Helpers
{
    public abstract class UIController : MonoBehaviour
    {
        [Inject] protected SignalBus _signalBus;

        private DOTweenAnimation _animation;

        protected virtual void Awake()
        {
            _animation = GetComponent<DOTweenAnimation>();
        }

        public virtual void Open()
        {
            _animation.DOPlay();
        }

        public virtual void Close()
        {
            _animation.DOPlayBackwards();
        }
    }
}