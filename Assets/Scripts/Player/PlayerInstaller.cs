using Player.Boosters.Signals;
using Player.Signals;
using Zenject;

namespace Player
{
    public class PlayerInstaller : Installer<PlayerInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<BoosterExpiredSignal>();
            Container.DeclareSignal<PlayerEarnBooster>();
            Container.DeclareSignal<PlayerEarnCurrencySignal>();

            Container.DeclareSignal<SetInitialCurrencySignal>();
            Container.DeclareSignal<SaveDataSignal>();

            Container.Bind<PlayerStateController>().AsSingle().NonLazy();
        }
    }
}