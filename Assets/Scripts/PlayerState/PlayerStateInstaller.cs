using Player;
using PlayerState.Boosters.Signals;
using PlayerState.Signals;
using Zenject;

namespace PlayerState
{
    public class PlayerStateInstaller : Installer<PlayerStateInstaller>
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