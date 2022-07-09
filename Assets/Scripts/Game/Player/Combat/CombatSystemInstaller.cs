using Game.Player.Combat.Signals;
using Zenject;

namespace Game.Player.Combat
{
    public class CombatSystemInstaller : Installer<CombatSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<ShootSignal>();
        }
    }
}