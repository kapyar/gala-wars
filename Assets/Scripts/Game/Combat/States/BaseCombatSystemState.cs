using Game.Combat.Signals;
using GameState.Bullet;
using GameState.Combat;
using UnityEngine;

namespace Game.Combat.States
{
    public abstract class BaseCombatSystemState
    {
        protected bool _isCanShoot;
        protected float _coolDownLeft;

        protected readonly AbstractCombatSystem _context;

        protected abstract CombatSystemType GetCombatSystemType();
        protected abstract void Shoot();

        private readonly BulletType _bulletType;

        public BaseCombatSystemState(AbstractCombatSystem context)
        {
            _context = context;
            //export to abstract
            _bulletType = _context.GameStateController.GetCombatSystemConfig(GetCombatSystemType()).BulletId;
        }

        public virtual void EnterState()
        {
            if (!_isCanShoot) return;

            Shoot();

            _context.SignalBus.Fire<ShootSignal>();

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

        protected void SpawnAtPos(GameObject go)
        {
            var tmp = GameObject.Instantiate(
                _context.PrefabsFactory.GetBullet(_bulletType),
                go.transform.position,
                go.transform.rotation
            );

            var bullet = tmp.GetComponent<Bullet.Bullet>();
            bullet.FromDto(_context.GameStateController.GetBulletConfig(_bulletType));

            bullet.Launch(go, _context.BulletOwner);
        }
    }
}