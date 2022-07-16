using alicewithalex.Configs;
using alicewithalex.Data;
using NoName.StateMachine;
using UnityEngine;

namespace alicewithalex.Views
{
    public class PlayerView : ViewComponent<GameStateData>
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _camera;
        [SerializeField] private LocomotionConfig _locomotionConfig;

        public override State State => State.Game;

        protected override void Process(GameStateData stateData)
        {
            stateData.Player = new Player(_characterController, _camera, _locomotionConfig);
        }
    }
}