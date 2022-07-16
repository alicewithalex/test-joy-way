using NoName.StateMachine;
using UnityEngine;

public abstract class StateDataProvider : MonoBehaviour,IStateDataProvider
{

    public abstract StateData GetData();
}
