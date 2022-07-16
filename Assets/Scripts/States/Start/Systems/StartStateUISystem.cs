using alicewithalex.Data;
using alicewithalex.UI;
using NoName.StateMachine;
using UnityEngine;

namespace alicewithalex.Systems
{
    public class StartStateUISystem : StateSystemWithScreen<StartStateData, StartUIScreen>
    {
        public override State State => State.Start;

        public override void StateEnter()
        {
            base.StateEnter();

            Screen.StartButton.onClick.AddListener(StartButtonPressed);
            Screen.ExitButton.onClick.AddListener(ExitButtonPressed);
        }

        public override void StateExit()
        {
            base.StateExit();

            Screen.StartButton.onClick.RemoveListener(StartButtonPressed);
            Screen.ExitButton.onClick.RemoveListener(ExitButtonPressed);
        }

        private void StartButtonPressed() => ChangeState(State.Game);

        private void ExitButtonPressed() => Application.Quit();

    }
}