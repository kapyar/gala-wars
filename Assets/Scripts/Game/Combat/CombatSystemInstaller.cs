using Game.Combat.Signals;
using Zenject;

namespace Game.Combat
{
    public class CombatSystemInstaller : Installer<CombatSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<ShootSignal>();
        }
    }
}