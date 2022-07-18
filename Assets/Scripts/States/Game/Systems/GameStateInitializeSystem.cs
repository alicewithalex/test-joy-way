using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;

namespace alicewithalex.Systems
{
    public class GameStateInitializeSystem : IInitializeSystem
    {
        [Inject] private readonly GameStateData _data;

        public void OnInitialize()
        {
            _data.Input = new GameInput(_data.InputConfig);
            _data.Enemy.OnStatusStopped += DestroyStatus;
        }

        private void DestroyStatus(Status status)
        {
            _data.Destroy(status);
        }
    }
}