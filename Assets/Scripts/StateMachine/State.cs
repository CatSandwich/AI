﻿namespace StateMachine
{
    public abstract class State
    {
        public virtual void Update() { }
        public virtual void Enter() { }
        public virtual void Exit() { }
    }
}