using alicewithalex.Data;
using NoName.StateMachine;
using UnityEngine;

namespace alicewithalex.Views
{
    public class PlayerView : ViewComponent<GameStateData>
    {
        [SerializeField] private CharacterController _characterController;

        public override State State => State.Game;

        protected override void Process(GameStateData stateData)
        {
            Player player = new Player();

            player.CharacterController = _characterController;
            player.Transform = _characterController.transform;

            stateData.Player = player;
        }
    }
}