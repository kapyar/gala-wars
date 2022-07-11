using Game.Enemy.Signals;
using GameState.Prefabs;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class FXController : MonoBehaviour
    {
        private PrefabsFactory _prefabsFactory;

        private SignalBus _signalBus;

        [Inject]
        public void Contruct(SignalBus signalBus, PrefabsFactory prefabsFactory)
        {
            _signalBus = signalBus;
            _prefabsFactory = prefabsFactory;

            _signalBus.Subscribe<EnemyDeathSignal>(OnEnemyDeathSignal);
        }

        private void OnEnemyDeathSignal(EnemyDeathSignal signal)
        {
            Debug.Log("FXController OnEnemyDeathSignal");

            var death = _prefabsFactory.GetFX("Death");
            Instantiate(death, signal.Transform.position, signal.Transform.rotation);
        }
    }
}