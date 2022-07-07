using PlayerInput.Signals;
using Zenject;

namespace PlayerInput
{
    public class PlayerInputInstaller : Installer<PlayerInputInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<PlayerChangeJoystickSignal>();
            Container.DeclareSignal<PlayerPressShootSignal>();
            Container.DeclareSignal<PlayerReleaseShootSignal>();
        }
    }
}