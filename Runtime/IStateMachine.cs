namespace IronMountain.StateMachines
{
    public interface IStateMachine<T> where T : IState
    {
        public T PreviousState { get; set; }
        public T CurrentState { get; set; }

        public bool RequestState(T requestedState);
        public void RequestPreviousState();
        public void ChangeToState(T newState);
    }
}