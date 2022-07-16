using NoName.StateMachine;
using UnityEngine;
using UnityEngine.UI;

public class ExampleStateData : StateData
{
    public override State State => State.Start;

    public Transform Player;
    public KeyCode NextStateKey;
}
