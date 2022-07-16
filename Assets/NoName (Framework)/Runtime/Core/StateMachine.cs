using NoName.Debugging;
using NoName.Factory;
using NoName.Injection;
using NoName.Saving;
using NoName.Signals;
using NoName.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NoName.StateMachine
{
    public class StateMachine : IStateMachine, ISavingPromoter, ILoadingEventProvider, ILoader
    {
        const int DEFAULT_SYSTEM_CAPACITY = 16;

        private readonly Dictionary<State, List<IStateSystem>> _systems =
            new Dictionary<State, List<IStateSystem>>();

        private readonly Dictionary<State, StateData> _data =
            new Dictionary<State, StateData>();

        private readonly Dictionary<Type, AbstractFactory> _factories =
          new Dictionary<Type, AbstractFactory>();

        private readonly ITimer<State> _timer;
        private readonly ICoroutineProvider _coroutineProvider;
        private readonly UIHub _uiHub;
        private readonly SavePromoter _savePromoter = new SavePromoter();

        private State _current;
        private StateTransition _stateTransition;
        private State _next;

        public StateMachine(State initialiState, UIHub uiHub,
            ITimer<State> timer, IContainer container,
            ICoroutineProvider coroutineProvider,
            IList<StateSystemsProvider> stateSystemsProviders,
            IList<StateDataProvider> stateDataProviders)
        {
            _next = _current = initialiState;
            _uiHub = uiHub;
            _timer = timer;
            _coroutineProvider = coroutineProvider;

            _uiHub.Initialize();

            //Init all states with empty or null references
            State state = default(State);
            foreach (var s in Enum.GetValues(typeof(State)))
            {
                state = (State)s;
                _data.Add(state, null);
                _systems.Add(state, new List<IStateSystem>(DEFAULT_SYSTEM_CAPACITY));
            }

            //Data
            foreach (var provider in stateDataProviders)
            {
                var data = provider.GetData();
                if (_data[data.State] is null)
                {
                    _data[data.State] = data;
                    _data[data.State].InjectRecursievly(this, typeof(ILoadingEventProvider));
                    _data[data.State].InjectRecursievly(this, typeof(ILoader));
                    _data[data.State].InjectRecursievly(this, typeof(IFactory), 1);
                    _data[data.State].InjectRecursievly(this, typeof(ISavingPromoter), 1);
                }
                else
                    throw new ArgumentException($"State data for ({data.State}) already was added!"
                        .Colorize(DColor.Magenta, true));
            }

            //Systems
            foreach (var provider in stateSystemsProviders)
            {
                foreach (var system in provider.GetStateSystems(container))
                {
                    _systems[system.State].Add(system);

                    //Inject state-machine,factory,UI hub and state data 
                    system.InjectRecursievly(this, typeof(IStateMachine), system.InheritanceDeep);
                    system.InjectRecursievly(uiHub, system.InheritanceDeep);
                    if (!(_data[system.State] is null))
                        system.InjectRecursievly(_data[system.State], system.InheritanceDeep);


                }
            }

            Initialize();
        }

        #region Private Methods

        private void Initialize()
        {
            // Initialize all views
            foreach (var viewComponent in GameObject.FindObjectsOfType<AbstractViewComponent>())
            {
                viewComponent.Process(_data[viewComponent.State]);
            }

            // Initialize all systems
            foreach (var systems in _systems.Values)
                foreach (var system in systems)
                    system.Initialize();

            // Invoke current state to state enter

            _stateTransition = StateTransition.Enter;
        }
        private void InvokeStateEnter(State state)
        {
            _uiHub.Show(state);
            foreach (var system in _systems[state])
                system.StateEnter();
        }
        private void InvokeStateExit(State state)
        {
            _uiHub.Hide(state);
            foreach (var system in _systems[state])
                system.StateExit();
        }

        private void ChangeStateInternal(State nextState)
        {
            _stateTransition = StateTransition.Exit;
            _next = nextState;
        }

        #endregion

        #region Core

        public void FixedTick()
        {
            foreach (var system in _systems[_current])
                system.StateFixedUpdate();
        }

        public void Tick()
        {
            if (_stateTransition.Equals(StateTransition.Enter))
            {
                _current = _next;
                InvokeStateEnter(_current);
                _stateTransition = StateTransition.None;
            }

            foreach (var system in _systems[_current])
                system.StateUpdate();

            if (_stateTransition.Equals(StateTransition.Exit))
            {
                InvokeStateExit(_current);
                _stateTransition = StateTransition.Enter;
            }

            if (_current.Equals(State.Loading) && !_loading)
            {
                _loading = true;

                if (_fadeIn)
                {
                    _uiHub.Fade(true, OnFadeValueChanged, OnScreenFadeIn);
                }
                else
                {
                    OnFadeValueChanged?.Invoke(1f);
                    OnScreenFadeIn();
                }
            }
        }


        public void LateTick()
        {
            foreach (var system in _systems[_current])
                system.StateLateUpdate();
        }

        public void Destroy()
        {
            foreach (var systems in _systems.Values)
                foreach (var system in systems)
                    system.Destroy();

        }

        #endregion

        #region Saving and Loading

        public event Action<int> OnSaved;
        public event Action<bool> OnLoadingStateChanged;
        public event Action<float> OnFadeValueChanged;
        public event Action<float> OnLoadingProgressChanged;

        private State _stateToLoad;
        private bool _loading;
        private bool _fadeOut;
        private bool _fadeIn;
        private int _loadSlot;

        public void Load(State nextState, bool fadeIn = true, bool fadeOut = true)
        {
            _loading = false;

            _fadeIn = fadeIn;
            _fadeOut = fadeOut;

            _stateToLoad = nextState;

            ChangeStateInternal(State.Loading);
        }

        public void Load(int slot = 0)
        {
            _loading = false;
            _stateToLoad = State.Game;

            _loadSlot = slot;
            ChangeStateInternal(State.Loading);
        }

        private void OnScreenFadeIn()
        {
            OnLoadingStateChanged?.Invoke(true);

            _coroutineProvider.Run(LoadRoutine());
        }

        private void OnScreenFadeOut()
        {
            ChangeStateInternal(_stateToLoad);

            _stateToLoad = State.None;
            _loading = false;
        }

        private IEnumerator LoadRoutine()
        {
            var loadData = _savePromoter.Load(_loadSlot);


            if (loadData.Count > 0)
            {
                int saveablesAmount = loadData.Values.Select(x => x.Count).Aggregate((x, y) => x + y);

                int i = 0;
                foreach (var loadPair in loadData)
                {
                    if (!_data.TryGetValue(loadPair.Key, out var stateData) || stateData == null) continue;

                    foreach (var savePair in loadPair.Value)
                    {
                        if (!stateData.Saveables.TryGetValue(savePair.Key, out var saveable)) continue;
                        saveable.OnLoad(savePair.Value);

                        OnLoadingProgressChanged?.Invoke(i * 1f / saveablesAmount);

                        i++;
                        yield return null;
                    }
                }

                OnLoadingStateChanged?.Invoke(false);
            }
            else
            {
                int ticks = 10;
                float duration = 1f;
                float current = 0;
                float delta = duration / ticks;

                OnLoadingProgressChanged?.Invoke(current);

                while (current < 1f)
                {
                    yield return new WaitForSeconds(delta);
                    current += delta;
                    OnLoadingProgressChanged?.Invoke(Mathf.Clamp01(current));
                }

                OnLoadingStateChanged?.Invoke(false);
            }


            Signals.Signals.Get<OnLoadingWasCompletedSignal>().Dispatch();

            if (_fadeOut)
            {
                _uiHub.Fade(false, OnFadeValueChanged, OnScreenFadeOut);
            }
            else
            {
                OnFadeValueChanged?.Invoke(0f);
                OnScreenFadeOut();
            }
        }

        public void LoadLastSave()
        {
            Load(_savePromoter.LastSlotSaved);
        }

        public void Save(int slot = 0)
        {
            foreach (var data in _data)
            {
                if (data.Value == null) continue;

                _savePromoter.Save(data.Key, data.Value.Saveables.Values.ToList(), slot);
            }

            OnSaved?.Invoke(slot);
        }

        public bool IsSlotEmpty(int slot)
        {
            return _savePromoter.IsSlotEmpty(slot);
        }


        #endregion

        #region Public Methods

        public void ChangeState(State nextState, float delay = 0)
        {
            if (_timer.Running)
                _timer.Cancel();

            if (delay > 0)
            {
                _timer.StartTimer(delay, nextState, ChangeStateInternal);
            }
            else
            {
                ChangeStateInternal(nextState);
            }
        }

        #endregion

    }
}