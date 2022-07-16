using NoName.EditorExtended;
using NoName.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NoName.StateMachine
{
    public class MonoStateMachine : MonoBehaviour, ITimer<State>, ICoroutineProvider
    {
        [SerializeField] private State _initialState;
        [SerializeField] private UIHub _uiHub;
        [SerializeField] private MonoContainer _monoContainer;
        [Space(16)]

        [SerializeField] private List<Binder> _binders;
        [SerializeField] private List<StateSystemsProvider> _stateSystemsProviders;
        [SerializeField] private List<StateDataProvider> _stateDataProviders;

        private StateMachine _stateMachine;
        private IEnumerator _timerRoutine;
        public bool Running => _timerRoutine != null;

        private void Awake()
        {
            _monoContainer.Initialize();

            _stateMachine = new StateMachine(_initialState, _uiHub, this, _monoContainer.Container,this,
                _stateSystemsProviders, _stateDataProviders);
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedTick();
        }

        private void Update()
        {
            _stateMachine.Tick();
        }

        private void LateUpdate()
        {
            _stateMachine.LateTick();
        }

        private void OnDestroy()
        {
            _stateMachine.Destroy();
        }

        public void Cancel()
        {
            StopCoroutine(_timerRoutine);
            _timerRoutine = null;
        }

        public void StartTimer(float duration, State value, Action<State> callback)
        {
            _timerRoutine = WaitThenDo(duration, value, callback);
            StartCoroutine(_timerRoutine);
        }

        private IEnumerator WaitThenDo<T>(float duration, T value, Action<T> callback)
        {
            yield return new WaitForSecondsRealtime(duration);
            callback?.Invoke(value);
            _timerRoutine = null;
        }

        public void Run(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }

        public void Stop(IEnumerator coroutine)
        {
            StopCoroutine(coroutine);
        }

#if UNITY_EDITOR

        [Button("Collect")]
        private void Collect()
        {
            _binders = GetComponentsInChildren<Binder>().ToList();
            _stateSystemsProviders = GetComponentsInChildren<StateSystemsProvider>().ToList();
            _stateDataProviders = GetComponentsInChildren<StateDataProvider>().ToList();

            _monoContainer = FindObjectOfType<MonoContainer>();
            _uiHub = FindObjectOfType<UIHub>();
        }

#endif
    }
}