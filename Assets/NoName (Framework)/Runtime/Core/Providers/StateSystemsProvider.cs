using NoName.StateMachine;
using NoName.Systems;
using UnityEngine;

public abstract class StateSystemsProvider : MonoBehaviour, IStateSystemProvider
{
    public abstract State State { get; }
    public abstract StateSystems GetStateSystems(IContainer container);
}
