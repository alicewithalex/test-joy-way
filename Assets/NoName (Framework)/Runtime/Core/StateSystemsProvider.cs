using NoName.StateMachine;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateSystemsProvider : MonoBehaviour, IStateSystemProvider
{
    public abstract IList<IStateSystem> GetStateSystems(IContainer container);
}
