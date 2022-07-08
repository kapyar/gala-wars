using System;
using GameState;

namespace GameConfig
{
    [Serializable]
    public class CombatSystemDto
    {
        public CombatSystemType Id;
        public BulletType BulletId;
        public float CoolDown;
    }
}