using NoName.Injection;
using NoName.StateMachine;
using UnityEngine;

namespace alicewithalex.Data
{
    public class LoadingStateData : StateData
    {
        public override State State => State.Loading;

        public Material OverlayMaterial;

        [Inject]
        public readonly ILoadingEventProvider LoadingEventProvider;

    }
}