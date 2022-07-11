using Game.Controllers.Level.Signals;
using Zenject;

namespace Game.Controllers.Level
{
    public class LevelInstaller : Installer<LevelInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<LevelEndedSignal>();
            Container.DeclareSignal<LevelStartedSignal>();
            Container.DeclareSignal<WaveEndedSignal>();
            Container.DeclareSignal<WaveStartedSignal>();
            Container.DeclareSignal<GameLevelsCompleted>();
        }
    }
}