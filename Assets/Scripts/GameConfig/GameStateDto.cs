using System;
using Player;

namespace GameConfig
{
    [Serializable]
    public class GameStateDto
    {
        public ReadOnlyPlayerData readOnlyPlayerData;
    }
}