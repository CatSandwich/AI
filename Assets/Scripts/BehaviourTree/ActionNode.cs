﻿using System;

namespace BehaviourTree
{
    public class ActionNode : INode
    {
        public ActionNode(Action action) => _action = action;
        private readonly Action _action;
        public bool? Evaluate()
        {
            _action();
            return true;
        }
    }
}
