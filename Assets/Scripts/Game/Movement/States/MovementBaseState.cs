namespace Game.Movement.States
{
    public abstract class MovementBaseState
    {
        protected AbstractMovementSystem _context;

        public abstract void EnterState();

        public abstract void FixedUpdate();

        public MovementBaseState(AbstractMovementSystem context)
        {
            _context = context;
            //export to abstract
        }
    }
}