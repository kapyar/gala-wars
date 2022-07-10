using System;

namespace GameState.Bullet
{
    [Serializable]
    public class BulletDto
    {
        public BulletType Id;
        public float Speed;
        public float Damage;
    }
}