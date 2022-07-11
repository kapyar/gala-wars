using Game.Player.Signals;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"BulletCollided with {other.name}");

            if (other.tag.Equals("EnemyBullet"))
            {
                OnCollideWithEnemyBullet(other);
            }
        }

        private void OnCollideWithEnemyBullet(Collider other)
        {
            var signal = new PlayerDiedSignal
            {
                Transform = transform
            };

            _signalBus.Fire(signal);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}