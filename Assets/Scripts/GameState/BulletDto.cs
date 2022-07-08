using System;
using GameState;

namespace GameConfig
{
    [Serializable]
    public class BulletDto
    {
        public BulletType Id;
        public float Speed;
        public float Damage;
    }
}