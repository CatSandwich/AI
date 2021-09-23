using UnityEngine;

namespace StateMachine
{
    public class FollowState : State
    {
        private readonly Enemy2 _script;
        
        public FollowState(Enemy2 script)
        {
            _script = script;
        }
        
        public override void Enter() => _script.Renderer.material = _script.Following;
        public override void Update() => _script.MoveTowards(_script.Target.position, Time.deltaTime * _script.Speed);
    }
}

/* Joshua Torrington-Smith
 * 2021-09-22 */