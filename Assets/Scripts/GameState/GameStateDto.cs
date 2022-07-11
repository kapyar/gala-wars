using System;
using System.Collections.Generic;
using GameState.Bullet;
using GameState.Combat;
using GameState.Level;
using GameState.Ships;

namespace GameConfig
{
    [Serializable]
    public class GameStateDto
    {
        public List<ShipDto> PlayerShipsDto = new List<ShipDto>();
        public List<EnemyShipDto> EnemyShipsDto = new List<EnemyShipDto>();
        public List<BulletDto> BulletsDto = new List<BulletDto>();
        public List<CombatSystemDto> CombatSystemDto = new List<CombatSystemDto>();

        public List<LevelDto> LevelDto = new List<LevelDto>();
    }
}