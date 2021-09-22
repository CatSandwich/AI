using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

/// <summary>Controls the behaviour of Enemy1s. They will navigate to the area, then begin their flocking behaviour.</summary>
/// <remarks>Joshua Torrington-Smith, 2021-09-20 - 2021-09-21</remarks>
public class Enemy1 : MonoBehaviour
{
    [Header("Flocking Manager")]
    [Tooltip("The speed of the enemies")]
    public float Speed;
    [Tooltip("The range in which other enemies are considered neighbors")]
    public float Range;
    [Tooltip("The desired minimum distance between enemies")]
    public float Distance;
    [Tooltip("The weighting of factors when determining movement")]
    public float Weight;

    [Header("Debug")]
    [Tooltip("Draw where the enemy is trying to go")]
    public bool DrawTarget;
    [Tooltip("Draw where the enemy is facing")]
    public bool DrawDirection;
    
    private bool _flocking;
    private NavMeshAgent _agent;
    private Vector3 _destination;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = Speed;
        _agent.destination = _destination = GameObject.FindGameObjectWithTag("Enemy1Destination").transform.position;
    }

    void FixedUpdate()
    {
        if (_agent.enabled) return;
        
        if (_flocking)
        {
            _flock();
        }
        else
        {
            _rotateTowards(_destination, 5f);
        }
        
        if (DrawDirection) Debug.DrawRay(transform.position, transform.forward, Color.blue, Time.fixedDeltaTime);
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    #region Keep in zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FlockingArea"))
        {
            _flocking = true;
            _agent.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FlockingArea"))
        {
            _flocking = false;
        }
    }
    #endregion

    #region Flocking
    private void _flock()
    {
        var tooClose = EnemySpawner.Enemies
            .Where(t => t != transform && (t.position - transform.position).magnitude <= Distance).ToArray();
        
        var neighbors = EnemySpawner.Enemies
            //.Where(enemy => enemy.GetComponent<Enemy1>().Flocking)
            .Where(t => t != transform && (t.position - transform.position).magnitude <= Range).ToArray();
        
        if (!neighbors.Any()) return;
        
        if (tooClose.Any())
        {
            _avoidance(tooClose.Select(t => t.position).ToArray());
        }
        else
        {
            _cohesion(neighbors.Select(t => t.position).ToArray());
        }
        _alignment(neighbors.Select(n => n.rotation));
    }

    private void _cohesion(Vector3[] neighbors)
    {
        var target = new Vector3(
            neighbors.Average(n => n.x), 
            0,
            neighbors.Average(n => n.z));
        
       if (DrawTarget) Debug.DrawLine(transform.position, target, Color.green, Time.fixedDeltaTime);
        _rotateTowards(target);
    }

    private void _avoidance(Vector3[] tooClose)
    {
        var target = new Vector3(
            tooClose.Average(n => n.x), 
            0,
            tooClose.Average(n => n.z));

        // Run away from target - formula from vector algebra
        target = 2 * transform.position - target;
        
        if (DrawTarget) Debug.DrawLine(transform.position, target, Color.red, Time.fixedDeltaTime);
        _rotateTowards(target, 3f);
    }

    private void _alignment(IEnumerable<Quaternion> neighbors)
    {
        var target = Quaternion.Euler(0, neighbors.Average(n => n.eulerAngles.y), 0);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, Weight * Time.deltaTime);
    }
    #endregion

    private void _rotateTowards(Vector3 target, float multi = 1f)
    {
        target.y = _destination.y;
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation, 
            Quaternion.LookRotation(target - transform.position), 
            Weight * Time.deltaTime * multi);
    }
}
