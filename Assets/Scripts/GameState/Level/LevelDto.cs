using System;
using System.Collections.Generic;

namespace GameState.Level
{
    [Serializable]
    public class LevelDto
    {
        public string Name;
        public List<WaveDto> WaveDto = new List<WaveDto>();
    }
}