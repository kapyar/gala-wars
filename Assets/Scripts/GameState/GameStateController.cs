using System.Linq;
using GameState.Bullet;
using GameState.Combat;
using GameState.Ships;
using Player;

namespace GameConfig
{
    public class GameStateController
    {
        public GameStateDto GameStateDto { get; }

        private readonly PlayerStateController _playerStateController;

        public GameStateController(GameStateDto gameStateDto, PlayerStateController playerStateController)
        {
            GameStateDto = gameStateDto;
            _playerStateController = playerStateController;
        }

        public BulletDto GetBulletConfig(BulletType id)
        {
            return GameStateDto.BulletsDto.FirstOrDefault(x => x.Id == id);
        }

        public CombatSystemDto GetCombatSystemConfig(CombatSystemType id)
        {
            return GameStateDto.CombatSystemDto.FirstOrDefault(x => x.Id == id);
        }

        public ShipDto GetPlayerShipConfig()
        {
            return GameStateDto.PlayerShipsDto.FirstOrDefault(x => x.Id == _playerStateController.PlayerData.ShipId);
        }

        public EnemyShipDto GetEnemyShipConfig(string id)
        {
            return GameStateDto.EnemyShipsDto.FirstOrDefault(x => x.Id == id);
        }
    }
}