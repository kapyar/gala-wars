using System;
using System.Collections.Generic;

namespace GameConfig
{
    [Serializable]
    public class GameStateDto
    {
        public PlayerShipDto PlayerShipsDto = new PlayerShipDto();
        public List<BulletDto> BulletsDto = new List<BulletDto>();
    }
}