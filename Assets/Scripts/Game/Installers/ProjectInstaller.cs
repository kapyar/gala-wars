using Player;
using Services.Files;
using UI.Overlay;
using Zenject;

public class ProjectInstaller : MonoInstaller<ProjectInstaller>
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        EnterNameUIInstaller.Install(Container);
        OverlayUIInstaller.Install(Container);

        PlayerInstaller.Install(Container);

        Container.Bind<IFileService>().To<FileService>().AsSingle();
    }
}