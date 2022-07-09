using Game;
using Game.Player.Combat;
using GameConfig;
using GameState.Prefabs;
using Player;
using PlayerInput;
using Services.Files;
using UI.GameOverController;
using UI.Overlay;
using Zenject;

public class ProjectInstaller : MonoInstaller<ProjectInstaller>
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        EnterNameUIInstaller.Install(Container);
        OverlayUIInstaller.Install(Container);
        GameOverUIInstaller.Install(Container);

        PlayerInstaller.Install(Container);
        PlayerInputInstaller.Install(Container);

        CombatSystemInstaller.Install(Container);

        Container.BindInterfacesAndSelfTo<AudioController>().AsSingle().NonLazy();

        Container.Bind<IFileService>().To<FileService>().AsSingle();
        Container.Bind<GameStateController>().AsSingle().NonLazy();
        Container.Bind<PrefabsFactory>().AsSingle().NonLazy();
    }
}