using System;
using System.Collections.Generic;
using BehaviourTree;
using StateMachine;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [Header("Config")]
    public Transform Target;
    public MeshRenderer Renderer;
    public float FollowRange;
    public float AttackRange;

    [Header("State Materials")]
    public Material Idle;
    public Material Following;
    public Material Attacking;

    [Header("Navigation")]
    public Transform[] Waypoints;
    public float Speed;
    [NonSerialized] public int CurrentWaypoint;
    
    #region FSM
    public StateEnum State
    {
        get => _state;
        set
        {
            if (value == _state) return;
            _states[_state].Exit();
            _state = value;
            _states[_state].Enter();
        }
    }
    private StateEnum _state = StateEnum.Idle;
    private readonly Dictionary<StateEnum, State> _states = new Dictionary<StateEnum, State>();
    #endregion
    
    private SelectorNode _root;

    void Start()
    {
        // Initialize FSM states
        _states[StateEnum.Idle] = new IdleState(this);
        _states[StateEnum.Attacking] = new AttackState(this);
        _states[StateEnum.Following] = new FollowState(this);
        
        // Behaviour tree
        _root = new SelectorNode // Finds first applicable state
        {
            new SequenceNode // Try attack
            {
                new ConditionNode(() => (Target.position - transform.position).magnitude <= AttackRange), // If close enough
                new ActionNode(() => State = StateEnum.Attacking) // Set to attack state
            },
            new SequenceNode // Try follow
            {
                new ConditionNode(() => (Target.position - transform.position).magnitude <= FollowRange), // If close enough
                new ActionNode(() => State = StateEnum.Following) // Set to follow state
            },
            new ActionNode(() => State = StateEnum.Idle) // Set to idle state
        };
    }
    
    void Update()
    {
        _root.Evaluate();
        _states[State].Update();
    }

    public float MoveTowards(Vector3 target, float distance)
    {
        target.y = transform.position.y;
        var remaining = distance - (transform.position - target).magnitude;
        transform.position = Vector3.MoveTowards(transform.position, target, distance);
        return remaining;
    }

    public enum StateEnum
    {
        Idle,
        Following,
        Attacking
    }
}
