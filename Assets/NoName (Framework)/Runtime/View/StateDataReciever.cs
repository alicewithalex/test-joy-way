using NoName.Data;
using System;

namespace NoName.Interfaces
{
    public abstract class StateDataReciever<T> : AbstractStateDataReciever where T : StateData
    {
        protected T Data { get; private set; }

        public override Type Type => typeof(T);

        public override void Receive(StateData stateData)
        {
            if (Data != null) return;

            Data = stateData as T;

            OnInitialize();
        }

        protected virtual void OnInitialize()
        {

        }
    }
}