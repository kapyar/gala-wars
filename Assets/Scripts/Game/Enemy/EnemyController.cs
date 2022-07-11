using Game.Combat;
using Game.Enemy.Signals;
using GameState.Ships;
using UnityEngine;
using Zenject;

namespace Game.Enemy
{
    public class EnemyController : AbstractShipController

    {
        private SignalBus _signalBus;

        [SerializeField] private AbstractCombatSystem _combatSystem;
        [SerializeField] private EnemyShipDto _dto;
        public EnemyShipDto Dto => _dto;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Start()
        {
            _combatSystem.SetState(_dto.CombatSystemId);
        }

        public void FromDto(EnemyShipDto dto)
        {
            _dto = dto;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"BulletCollided with {other.name}");

            if (other.tag.Equals("PlayerBullet"))
            {
                OnCollideWithPlayerBullet(other);
            }
        }

        private void OnCollideWithPlayerBullet(Collider other)
        {
            var signal = new EnemyDeathSignal
            {
                Transform = transform
            };

            _signalBus.Fire(signal);

            foreach (var rewardDto in _dto.RewardDto)
            {
                var guess = Random.Range(0, 1);

                if (!(guess < rewardDto.Probability)) continue;

                var amount = Random.Range(rewardDto.From, rewardDto.To);

                var earnMoneySignal = new EnemyRewardDroppedSignal
                {
                    Amount = amount,
                    Type = rewardDto.Type
                };

                _signalBus.Fire(earnMoneySignal);
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        public override ShipDto GetShipDto()
        {
            return _dto;
        }
    }
}