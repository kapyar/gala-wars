using UI.EnterNameController.Signals;
using Zenject;

public class EnterNameUIInstaller : Installer<EnterNameUIInstaller>
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<SubmitNameSignal>();
    }
}