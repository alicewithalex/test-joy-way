using alicewithalex.Data;
using NoName.StateMachine;
using UnityEngine;

namespace alicewithalex.Systems
{
    public class PlayerMovementSystem : StateSystem<GameStateData>
    {
        public override State State => State.Game;

        public override void StateUpdate()
        {
            base.StateUpdate();

            if (StateData.Player is null) return;

            StateData.Player.ApplyMovement(InputDirection, Time.deltaTime);
        }
    }
}