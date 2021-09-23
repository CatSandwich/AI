using UnityEngine;

namespace StateMachine
{
    public class IdleState : State
    {
        private readonly Enemy2 _script;
        
        public IdleState(Enemy2 script)
        {
            _script = script;
        }
        
        public override void Enter() => _script.Renderer.material = _script.Idle;

        public override void Update()
        {
            var distance = Time.deltaTime * _script.Speed;
            while (true)
            {
                distance = _script.MoveTowards(_script.Waypoints[_script.CurrentWaypoint].position, distance);
                if (distance <= 0f) break;
                _script.CurrentWaypoint++;
                if (_script.CurrentWaypoint >= _script.Waypoints.Length) _script.CurrentWaypoint = 0;
            }
        }
    }
}

/* Joshua Torrington-Smith
 * 2021-09-22 */