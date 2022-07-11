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


        public void CopyTo(PlayerShipDto dto)
        {
            Id = dto.Id;
            Speed = dto.Speed;
            CombatSystemId = dto.CombatSystemId;
        }
    }
}