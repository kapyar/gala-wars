using System.Linq;
using GameState;
using Player;

namespace GameConfig
{
    public class GameStateController
    {
        public GameStateDto GameStateDto { get; }

        private PlayerStateController _playerStateController;

        public GameStateController(GameStateDto gameStateDto, PlayerStateController playerStateController)
        {
            GameStateDto = gameStateDto;
            _playerStateController = playerStateController;
        }

        public BulletDto GetBulletConfig(BulletType id)
        {
            return GameStateDto.BulletsDto.FirstOrDefault(x => x.Id == id);
        }

        public ShipDto GetShipConfig(string id)
        {
            return GameStateDto.ShipsDto.FirstOrDefault(x => x.Id == id);
        }

        public CombatSystemDto GetCombatSystemConfig(CombatSystemType id)
        {
            return GameStateDto.CombatSystemDto.FirstOrDefault(x => x.Id == id);
        }

        public ShipDto GetPlayerShipConfig()
        {
            return GameStateDto.ShipsDto.FirstOrDefault(x => x.Id == _playerStateController.PlayerData.ShipId);
        }
    }
}