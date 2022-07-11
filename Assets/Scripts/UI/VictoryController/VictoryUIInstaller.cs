using UI.VictoryController.Signals;
using Zenject;

namespace UI.VictoryController
{
    public class VictoryUIInstaller : Installer<VictoryUIInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<StartGameAfterCompleteSignal>();
        }
    }
}