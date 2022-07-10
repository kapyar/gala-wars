using GameState.Bullet;
using UnityEngine;

namespace Game.Combat.Bullet
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private float _speed;
        private float _damage;

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

        public void FromDto(BulletDto dto)
        {
            _speed = dto.Speed;
            _damage = dto.Damage;
        }

        public void Launch(GameObject spawnPoint)
        {
            RG.velocity = spawnPoint.transform.forward * _speed;
        }
    }
}