using GameState;
using UnityEngine;

namespace Game.Player.Combat.States
{
    public abstract class BaseCombatSystemState
    {
        protected bool _isCanShoot;
        protected float _coolDownLeft;

        protected PlayerCombatSystemContext _context;
        
        protected abstract CombatSystemType GetCombatSystemType();
        protected abstract void Shoot();

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