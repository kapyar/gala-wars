using UI.GameOverController.Signals;
using Zenject;

namespace UI.GameOverController
{
    public class GameOverUIInstaller : Installer<GameOverUIInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<RessurectSignal>();
            Container.DeclareSignal<OpenGameOverWindowSignal>();
            Container.DeclareSignal<QuitGameSignal>();
        }
    }
}