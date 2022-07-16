using alicewithalex.Data;
using NoName.StateMachine;
using UnityEngine;

namespace alicewithalex.Systems
{
    public class PlayerGravitationSystem : StateSystem<GameStateData>
    {
        public override State State => State.Game;

        public override void StateUpdate()
        {
            base.StateUpdate();

            if (StateData.Player is null) return;

            StateData.Player.ApplyGravity(Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
                StateData.Player.Jump();
        }
    }
}