using NoName.Injection;
using UnityEngine;

namespace NoName.StateMachine
{
    [System.Serializable]
    public abstract class StateSystem<T> : IStateSystem where T : StateData
    {
        public virtual int InheritanceDeep => 1;

        public abstract State State { get; }

        [Inject]
        private readonly T _stateData;

        [Inject]
        private readonly IStateMachine _stateMachine;

        private Vector2 _input;

        public T StateData => _stateData;

        protected Vector2 InputDirection => _input.normalized;

        protected Vector2 MouseInput => new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));

        protected bool InputValid => InputDirection != Vector2.zero;

        public void ChangeState(State nextState, float delay = 0)
        {
            _stateMachine.ChangeState(nextState, delay);
        }

        public virtual void Destroy()
        {
        }

        public virtual void Initialize()
        {
        }

        public virtual void StateEnter()
        {
        }

        public virtual void StateExit()
        {
        }

        public virtual void StateUpdate()
        {
            _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        public virtual void StateFixedUpdate()
        {
        }

        public virtual void StateLateUpdate()
        {
        }
    }
}