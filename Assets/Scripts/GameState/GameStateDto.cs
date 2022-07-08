using System;
using System.Collections.Generic;

namespace GameConfig
{
    [Serializable]
    public class GameStateDto
    {
        public List<ShipDto> ShipsDto = new List<ShipDto>();
        public List<BulletDto> BulletsDto = new List<BulletDto>();
        public List<CombatSystemDto> CombatSystemDto = new List<CombatSystemDto>();
    }
}