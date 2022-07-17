using NoName.Debugging;
using System;
using UnityEngine;

namespace NoName.StateMachine
{
    public class StateMachine : IStateMachine
    {
        private State _current;
        private State _next;

        private StateTransition _stateTransition;

        private bool _dirty;

        public State State => _current;

        public event Action<State> OnStateEnter;
        public event Action<State> OnStateUpdate;
        public event Action<State> OnStateExit;

        public StateMachine(State initialiState)
        {
            _current = State.None;
            _next = initialiState;

            _stateTransition = StateTransition.Enter;
        }

        public void Tick()
        {
            if (_stateTransition.Equals(StateTransition.Enter))
            {
                _current = _next;
                OnStateEnter?.Invoke(_current);

                Debug.Log($"{"State Enter:".Colorize(DColor.White, true)} {_current.Colorize(DColor.Orange)}");

                if (!_dirty)
                {
                    _next = State.None;
                    _stateTransition = StateTransition.None;
                }
            }

            if (_stateTransition.Equals(StateTransition.None))
            {
                OnStateUpdate?.Invoke(_current);
            }

            if (_stateTransition.Equals(StateTransition.Exit))
            {
                OnStateExit?.Invoke(_current);

                Debug.Log($"{"State Exit:".Colorize(DColor.White, true)} {_current.Colorize(DColor.Orange)}");

                if (!_dirty) _stateTransition = StateTransition.Enter;
            }
        }

        public void ChangeState(State nextState)
        {
            _dirty = true;

            _stateTransition = StateTransition.Exit;
            _next = nextState;
        }
    }
}