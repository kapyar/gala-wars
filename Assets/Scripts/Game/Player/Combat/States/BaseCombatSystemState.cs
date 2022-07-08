using GameState;
using UnityEngine;

namespace Game.Player.Combat.States
{
    public abstract class BaseCombatSystemState
    {
        protected bool _isCanShoot;
        protected float _coolDownLeft;

        protected abstract CombatSystemType GetCombatSystemType();
        protected abstract void Shoot();

        public virtual void EnterState(PlayerCombatSystemContext context)
        {
            if (!_isCanShoot) return;

            Shoot();

            _isCanShoot = false;
            _coolDownLeft = context.GameStateController.GetCombatSystemConfig(GetCombatSystemType()).CoolDown;
        }

        public virtual void Update(PlayerCombatSystemContext context)
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