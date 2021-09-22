﻿using System;
using UnityEngine;

namespace BehaviourTree
{
    public class ConditionNode : INode
    {
        public ConditionNode(Func<bool?> condition) => Condition = condition;
        
        public Func<bool?> Condition;
        public bool? Evaluate() => Condition();
    }
}
