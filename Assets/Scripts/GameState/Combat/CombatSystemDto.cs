using System;
using GameState.Bullet;

namespace GameState.Combat
{
    [Serializable]
    public class CombatSystemDto
    {
        public CombatSystemType Id;
        public BulletType BulletId;
        public float CoolDown;
    }
}