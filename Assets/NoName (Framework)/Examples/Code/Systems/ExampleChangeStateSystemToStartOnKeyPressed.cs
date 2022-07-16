using NoName.StateMachine;
using UnityEngine;

public class ExampleChangeStateSystemToStartOnKeyPressed : StateSystem<ExampleGameStateData>
{
    public override State State => State.Game;

    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void StateEnter()
    {
        base.StateEnter();

        var cube = Factories.Get<ExampleShapeFactory>().Create(Shape.Cube);
        cube.name = "Cube created by Factory!";
        cube.transform.position = new Vector3(2, 2, 0);
    }

    public override void StateExit()
    {
        base.StateExit();

        Debug.Log($"Exiting {State} state");
    }
}
