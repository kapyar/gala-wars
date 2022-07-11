using Zenject;

namespace Game
{
    public class LeaderboardInstaller : Installer<LeaderboardInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<LeaderboardController>().AsSingle().NonLazy();
        }
    }
}