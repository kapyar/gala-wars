using UnityEngine;

namespace Game.Helpers
{
    public class Mover : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private Rigidbody RG
        {
            get
            {
                if (_rigidbody == null)
                {
                    _rigidbody = GetComponent<Rigidbody>();
                }

                return _rigidbody;
            }
        }

        public void Launch(GameObject spawnPoint, float speed)
        {
            RG.velocity = spawnPoint.transform.forward * speed;
        }
    }
}