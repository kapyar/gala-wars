using UI.Overlay.Signals;
using Zenject;

namespace UI.Overlay
{
    public class OverlayUIInstaller : Installer<OverlayUIInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<OpenUIControllerSignal>();
            Container.DeclareSignal<CloseUIControllerSignal>();
        }
    }
}