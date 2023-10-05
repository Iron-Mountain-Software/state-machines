using System;
using UnityEngine;

namespace IronMountain.StateMachines
{
    public class StateMachine<T> : IStateMachine<T> where T : IState
    {
        public event Action OnStateChange;

        public T PreviousState { get; set; }
        public T CurrentState { get; set; }
        
        public Type PreviousStateType { get; set; }
        public Type CurrentStateType { get; set; }
        
        public float TimeOfLastStateChange { get; private set; }
        public float SecondsSinceLastStateChange => Time.time - TimeOfLastStateChange;
        
        public float UnscaledTimeOfLastStateChange { get; private set; }
        public float UnscaledSecondsSinceLastStateChange => Time.unscaledTime - UnscaledTimeOfLastStateChange;

        public static bool IsValidTransition(T startState, T endState)
        {
            return startState == null
                   || endState == null
                   || startState.CanTransitionTo(endState);
        }

        public bool RequestState(T requestedState)
        {
            if (!IsValidTransition(CurrentState, requestedState)) return false;
            ChangeToState(requestedState);
            return true;
        }

        public void RequestPreviousState() => RequestState(PreviousState);

        public void ChangeToState(T newState)
        {
            CurrentState?.Exit();
            PreviousState = CurrentState;
            PreviousStateType = PreviousState?.GetType();
            CurrentState = newState;
            CurrentStateType = CurrentState?.GetType();
            TimeOfLastStateChange = Time.time;
            UnscaledTimeOfLastStateChange = Time.unscaledTime;
            CurrentState?.Enter();
            OnStateChange?.Invoke();
        }

        public StateMachine<T> Initialize(T initialState)
        {
            PreviousState = default;
            PreviousStateType = null;
            CurrentState = initialState;
            CurrentStateType = CurrentState?.GetType();
            CurrentState?.Enter();
            return this;
        }

        public StateMachine()
        {
            PreviousState = default;
            PreviousStateType = null;
            CurrentState = default;
            CurrentStateType = null;
        }
    }
}