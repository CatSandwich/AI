using System;
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
    
    private SelectorNode _root;

    public State State;

    void Start()
    {
        State = new IdleState(this);
        
        // Behaviour tree
        _root = new SelectorNode // Finds first applicable state
        {
            new SequenceNode // Try attack
            {
                new ConditionNode(() => (Target.position - transform.position).magnitude <= AttackRange), // If close enough
                new ActionNode(() => PushState(new AttackState(this))) // Set to attack state
            },
            new SequenceNode // Try follow
            {
                new ConditionNode(() => (Target.position - transform.position).magnitude <= FollowRange), // If close enough
                new ActionNode(() => PushState(new FollowState(this))) // Set to follow state
            },
            new ActionNode(() => PushState(new IdleState(this))) // Set to idle state
        };
    }
    
    void Update()
    {
        _root.Evaluate();
        State.Update();
    }

    public void PushState(State state)
    {
        State.Exit();
        State = state;
        State.Enter();
    }

    public float MoveTowards(Vector3 target, float distance)
    {
        target.y = transform.position.y;
        var remaining = distance - (transform.position - target).magnitude;
        transform.position = Vector3.MoveTowards(transform.position, target, distance);
        return remaining;
    }
}
