using Game.Helpers;
using GameState;
using UnityEngine;

namespace Game.Player.Combat.States
{
    public abstract class BaseCombatSystemState
    {
        protected bool _isCanShoot;
        protected float _coolDownLeft;

        protected readonly PlayerCombatSystemContext _context;

        protected abstract CombatSystemType GetCombatSystemType();
        protected abstract void Shoot();

        protected void SpawnAtPos(GameObject go)
        {
            var bulletID = _context.GameStateController.GetCombatSystemConfig(GetCombatSystemType()).BulletId;

            var bullet = GameObject.Instantiate(
                _context.PrefabsFactory.GetBullet(bulletID),
                go.transform.position,
                go.transform.rotation
            );

            bullet.GetComponent<Mover>().Launch(_context.GameStateController.GetBulletConfig(bulletID).Speed);
        }

        public BaseCombatSystemState(PlayerCombatSystemContext context)
        {
            _context = context;
        }

        public virtual void EnterState()
        {
            if (!_isCanShoot) return;

            Shoot();

            _isCanShoot = false;
            _coolDownLeft = _context.GameStateController.GetCombatSystemConfig(GetCombatSystemType()).CoolDown;
        }

        public virtual void Update()
        {
            if (_isCanShoot) return;

            if (_coolDownLeft <= 0)
            {
                _isCanShoot = true;
            }

            _coolDownLeft -= Time.deltaTime;
        }
    }
}