using alicewithalex.Data;
using alicewithalex.UI;
using NoName.Injection;
using NoName.Enums;
using NoName.Systems;
using NoName.UI;
using UnityEngine;

namespace alicewithalex.Systems
{
    public class StartMenuSystem : UISystem<StartUIScreen>, IStateEnterSystem, IStateExitSystem
    {
        [Inject]
        private readonly IStateMachine _stateMachine;

        public StartMenuSystem(UIHub uiHub) : base(uiHub)
        {
        }

        public override State State => State.Start;

        public void StateEnter()
        {
            Screen.StartButton.onClick.AddListener(StartButtonPressed);
            Screen.ExitButton.onClick.AddListener(ExitButtonPressed);
        }

        public void StateExit()
        {
            Screen.StartButton.onClick.RemoveListener(StartButtonPressed);
            Screen.ExitButton.onClick.RemoveListener(ExitButtonPressed);
        }

        private void StartButtonPressed() => _stateMachine.ChangeState(State.Game);

        private void ExitButtonPressed() => Application.Quit();

    }
}