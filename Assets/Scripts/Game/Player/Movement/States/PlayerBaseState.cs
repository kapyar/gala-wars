namespace Game.Player.Movement.States
{
    public abstract class PlayerBaseState
    {
        public abstract void EnterState(PlayerContext context);

        public abstract void Update(PlayerContext context);
    }
}