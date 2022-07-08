using UnityEngine;

namespace Game.Helpers
{
    public class Mover : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Launch(float speed)
        {
            _rigidbody.velocity = transform.forward * speed;
        }
    }
}