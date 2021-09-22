using UnityEngine;

namespace StateMachine
{
    public class AttackState : State
    {
        private readonly Enemy2 _script;
        
        public AttackState(Enemy2 script)
        {
            _script = script;
        }
        
        public override void Enter() => _script.Renderer.material = _script.Attacking;
        public override void Update() => _script.MoveTowards(_script.Target.position, Time.deltaTime * _script.Speed);
    }
}
