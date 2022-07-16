using NoName.StateMachine;
using UnityEngine;

public class ExampleGameStateData : StateData
{
    public override State State => State.Game;

    public KeyCode NextStateKey;
}
