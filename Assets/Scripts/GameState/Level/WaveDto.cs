using System;
using System.Collections.Generic;

namespace GameState.Level
{
    [Serializable]
    public class WaveDto
    {
        public List<WaveEnemyDto> WaveEnemyDtos = new List<WaveEnemyDto>();
        public float Delay;
    }
}