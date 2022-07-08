using Game.Helpers;
using GameState;
using UnityEngine;

namespace Game.Player.Combat.States
{
    public class StartPlayerCombatSystemState : BaseCombatSystemState
    {
        protected override CombatSystemType GetCombatSystemType()
        {
            return CombatSystemType.StartPlayer;
        }

        protected override void Shoot()
        {
            var bulletID = _context.GameStateController.GetCombatSystemConfig(GetCombatSystemType()).BulletId;

            var pos = _context.GunHolder.Cannon;

            var bullet = GameObject.Instantiate(
                _context.PrefabsFactory.GetBullet(bulletID),
                pos.transform.position,
                pos.transform.rotation
            );

            bullet.GetComponent<Mover>().Launch(_context.GameStateController.GetBulletConfig(bulletID).Speed);
        }

        public StartPlayerCombatSystemState(PlayerCombatSystemContext context) : base(context)
        {
        }
    }
}