namespace IronMountain.StateMachines
{
    public interface IState
    {
        public bool CanTransitionTo(IState state);
        public void Enter();
        public void Exit();
    }
}