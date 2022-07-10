using System;
using System.Collections.Generic;
using GameConfig;

namespace GameState.Ships
{
    [Serializable]
    public class EnemyShipDto : PlayerShipDto
    {
        public List<RewardDto> RewardDto = new List<RewardDto>();
    }
}