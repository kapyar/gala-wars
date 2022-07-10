using System;
using GameState.Combat;

namespace GameState.Ships
{
    [Serializable]
    public class PlayerShipDto
    {
        public string Id;
        public float Speed;
        public CombatSystemType CombatSystemId;
    }
}