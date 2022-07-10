using UI.WelcomeScreen.Signals;
using Zenject;

namespace UI.WelcomeScreen
{
    public class WelcomeScreenUIInstaller : Installer<WelcomeScreenUIInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<ContinueGameSignal>();
        }
    }
}