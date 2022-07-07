namespace Game.Player.States
{
    public abstract class PlayerBaseState
    {
        public abstract void EnterState(PlayerContext context);

        public abstract void Update(PlayerContext context);
    }
}