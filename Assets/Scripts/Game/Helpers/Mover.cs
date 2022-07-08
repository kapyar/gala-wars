using UnityEngine;

namespace Game.Helpers
{
    public class Mover : MonoBehaviour
    {
        private Rigidbody _rigidbody;


        [SerializeField] private float _speed;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _rigidbody.velocity = transform.forward * _speed;
        }
    }
}