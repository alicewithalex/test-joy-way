using NoName.StateMachine;
using UnityEngine;

public class ExamplePlayerMoveSystem : StateSystem<ExampleStateData>
{
    public override State State => State.Start;

    public override void StateUpdate()
    {
        base.StateUpdate();
        StateData.Player.position += Vector3.forward * Time.deltaTime;
    }
}
