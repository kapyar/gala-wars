using Game.Enemy.Signals;
using Zenject;

namespace Game.Enemy
{
    public class EnemyInstaller : Installer<EnemyInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<EnemyDeathSignal>();
        }
    }
}