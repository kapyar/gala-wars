using Game.Player.Signals;
using Zenject;

namespace Game.Player
{
    public class PlayerInstaller : Installer<PlayerInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<PlayerDiedSignal>();
        }
    }
}