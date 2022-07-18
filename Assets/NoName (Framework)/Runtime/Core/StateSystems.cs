using NoName.Injection;
using NoName.Enums;
using System;
using System.Collections.Generic;

namespace NoName.Systems
{
    public class StateSystems
    {
        public readonly State State;

        private readonly List<ISystem> _systems;

        private readonly List<IStateUpdateSystem> _stateUpdateSystems;
        private readonly List<IStateEnterSystem> _stateEnterSystems;
        private readonly List<IStateExitSystem> _stateExitSystems;

        public StateSystems(State state)
        {
            State = state;

            _systems = new List<ISystem>();

            _stateUpdateSystems = new List<IStateUpdateSystem>();
            _stateEnterSystems = new List<IStateEnterSystem>();
            _stateExitSystems = new List<IStateExitSystem>();
        }

        public StateSystems Add(ISystem system)
        {
            _systems.Add(system);

            if (system is IStateUpdateSystem stateUpdateSystem)
            {
                _stateUpdateSystems.Add(stateUpdateSystem);
            }

            if (system is IStateEnterSystem stateEnterSystem)
            {
                _stateEnterSystems.Add(stateEnterSystem);
            }

            if (system is IStateExitSystem stateExitSystem)
            {
                _stateExitSystems.Add(stateExitSystem);
            }


            return this;
        }

        public void Join(StateSystems systems)
        {
            foreach (var system in systems._systems)
            {
                Add(system);
            }
        }

        public void Initialize()
        {
            foreach (var system in _systems)
            {
                if (system is IInitializeSystem initSystem)
                {
                    initSystem.OnInitialize();
                }
            }
        }

        public void StateEnter()
        {
            foreach (var system in _stateEnterSystems)
            {
                system.StateEnter();
            }
        }

        public void StateUpdate()
        {
            //UnityEngine.Debug.Log($"Update:{State}");

            foreach (var system in _stateUpdateSystems)
            {
                system.StateUpdate();
            }
        }

        public void StateExit()
        {
            foreach (var system in _stateExitSystems)
            {
                system.StateExit();
            }
        }

        public void Destroy()
        {
            foreach (var system in _systems)
            {
                if (system is IDestroySystem destroySystem)
                {
                    destroySystem.OnDestroy();
                }
            }
        }

        public void Inject<T>(T @object)
        {
            Inject(@object, typeof(T));
        }

        public void Inject(object @object, Type type)
        {
            foreach (var system in _systems)
            {
                system.Inject(@object, type);
            }
        }
    }
}