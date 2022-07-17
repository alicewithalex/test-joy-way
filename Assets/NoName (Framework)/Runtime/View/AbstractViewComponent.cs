using NoName.Data;
using NoName.StateMachine;
using UnityEngine;

public abstract class AbstractViewComponent : MonoBehaviour
{
    public abstract void Process(StateData stateData);

    public abstract State State { get; }

}
