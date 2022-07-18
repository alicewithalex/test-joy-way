using NoName.Data;
using NoName.Providers;
using NoName.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace NoName.Enums
{
    public class Bootstrap : MonoBehaviour
    {
        [Space(8)]
        [SerializeField] private State _initialState;

        [Space(8)]
        [SerializeField] private UnityEvent<State> _onStateEnter;
        [SerializeField] private UnityEvent<State> _onStateExit;

        [Space(16)]
        [SerializeField] private MonoContainer _monoContainer;
        [Space(8)]
        [SerializeField] private List<AbstractStateSystemsProvider> _stateSystemsProviders;
        [SerializeField] private List<AbstractStateDataProvider> _stateDataProviders;

        private StateMachine _stateMachine;

        private Dictionary<State, StateSystems> _systems;
        private Dictionary<State, StateData> _data;

        #region Core

        private void SetupStateMachine()
        {
            _stateMachine = new StateMachine(_initialState);

            _stateMachine.OnStateEnter += SystemsStateEnter;
            _stateMachine.OnStateUpdate += SystemsStateUpdate;
            _stateMachine.OnStateExit += SystemsStateExit;

            _stateMachine.OnStateEnter += CustomStateEnter;
            _stateMachine.OnStateExit += CustomStateExit;
        }

        private void SetupData()
        {
            _data = new Dictionary<State, StateData>();

            foreach (var provider in _stateDataProviders)
            {
                if (!_data.ContainsKey(provider.State))
                {
                    _data.Add(provider.State, provider.GetData(_monoContainer.Container));
                }
                else
                {
                    throw new ArgumentException("An item with the same key has already been added");
                }
            }
        }

        private void SetupSystems()
        {
            _systems = new Dictionary<State, StateSystems>();

            foreach (var provider in _stateSystemsProviders)
            {
                if (!_systems.ContainsKey(provider.State))
                {
                    _systems.Add(provider.State, provider.GetStateSystems(_monoContainer.Container));
                }
                else
                {
                    _systems[provider.State].Join(provider.GetStateSystems(_monoContainer.Container));
                }

                // State Machine
                _systems[provider.State].Inject(_stateMachine, typeof(IStateMachine));

                // State data
                if (_data.TryGetValue(provider.State, out var data))
                    _systems[provider.State].Inject(data, data.GetType());
            }
        }

        private void SetupViews()
        {
            Dictionary<Type, StateData> _dataMap = _data.Values.ToDictionary(x => x.GetType());

            foreach (var receiver in FindObjectsOfType<AbstractStateDataReciever>(true))
            {
                if (_dataMap.ContainsKey(receiver.Type))
                    receiver.Receive(_dataMap[receiver.Type]);
            }
        }

        private void InitializeSystems()
        {
            foreach (var systems in _systems.Values)
            {
                systems.Initialize();
            }
        }

        private void SystemsStateEnter(State state) => _systems[state].StateEnter();
        private void SystemsStateUpdate(State state) => _systems[state].StateUpdate();
        private void SystemsStateExit(State state) => _systems[state].StateExit();

        private void CustomStateEnter(State state) => _onStateEnter?.Invoke(state);
        private void CustomStateExit(State state) => _onStateExit?.Invoke(state);

        #endregion

        #region Unity Methods

        private void Awake()
        {
            _monoContainer.Initialize();

            SetupStateMachine();
            SetupData();
            SetupSystems();
            SetupViews();
            InitializeSystems();
        }



        private void Update()
        {
            _stateMachine.Tick();
        }

        private void OnDestroy()
        {
            foreach (var system in _systems.Values)
            {
                system.Destroy();
            }

            _systems.Clear();

            _stateMachine.OnStateEnter -= SystemsStateEnter;
            _stateMachine.OnStateUpdate -= SystemsStateUpdate;
            _stateMachine.OnStateExit -= SystemsStateExit;

            _stateMachine.OnStateEnter -= CustomStateEnter;
            _stateMachine.OnStateExit -= CustomStateExit;
        }

        #endregion

        #region Editor

        [EditorExtended.Button("Collect")]
        private void Collect()
        {
            _stateSystemsProviders = GetComponentsInChildren<AbstractStateSystemsProvider>().ToList();
            _stateDataProviders = GetComponentsInChildren<AbstractStateDataProvider>().ToList();
            _monoContainer = FindObjectOfType<MonoContainer>();

#if UNITY_EDITOR

            UnityEditor.EditorUtility.SetDirty(this);
#endif
        }

        #endregion
    }
}