using NoName.Data;
using NoName.StateMachine;
using UnityEngine;

public abstract class StateDataProvider : MonoBehaviour, IStateDataProvider
{
    public abstract State State { get; }
    public abstract StateData GetData();
}
