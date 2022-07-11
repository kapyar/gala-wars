using System;
using Game.Combat;
using Game.Player.Signals;
using GameState.Ships;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        private SignalBus _signalBus;

        [SerializeField] private PlayerShipDto _dto;
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

        public void FromDto(PlayerShipDto dto)
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
    }
}