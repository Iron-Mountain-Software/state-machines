using UnityEngine;

namespace IronMountain.StateMachines
{
    public abstract class ScriptedState : ScriptableObject, IState
    {
        public virtual bool CanTransitionTo(IState state) => true;
        public abstract void Enter();
        public abstract void Exit();
    }
}