using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;

namespace alicewithalex.Systems
{
    public class StatusesCleanupSystem : IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _data;


        public void StateUpdate()
        {
            if (!_data.Exist<Status>(out var statuses)) return;

            foreach (var status in statuses)
            {
                _data.Statuses.Remove(status);
            }
        }
    }
}