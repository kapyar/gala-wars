using Game.Enemy.Signals;
using UnityEngine;
using Zenject;

namespace Game.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private SignalBus _signalBus;


        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"BulletCollided with {other.name}");

            if (other.tag.Equals("Bullet"))
            {
                var signal = new EnemyDeathSignal
                {
                    Transform = transform
                };
                _signalBus.Fire(signal);
            }
        }
    }
}