using Game.Combat;
using Game.Player.Signals;
using GameState.Ships;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerController : AbstractShipController
    {
        private SignalBus _signalBus;

        [SerializeField] private ShipDto _dto;
        [SerializeField] private AbstractCombatSystem _combatSystem;


        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Start()
        {
            _combatSystem.SetState(_dto.CombatSystemId);
        }

        public void FromDto(ShipDto dto)
        {
            _dto = dto;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("EnemyBullet"))
            {
                OnCollideWithEnemyBullet(other);
            }
        }

        private void OnCollideWithEnemyBullet(Collider other)
        {
            Debug.Log("OnCollideWithEnemyBullet");

            var signal = new PlayerDiedSignal
            {
                Transform = transform
            };

            _signalBus.Fire(signal);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        public override ShipDto GetShipDto()
        {
            return _dto;
        }
    }
}