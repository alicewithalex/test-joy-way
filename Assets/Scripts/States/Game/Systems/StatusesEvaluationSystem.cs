using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;
using UnityEngine;

namespace alicewithalex.Systems
{
    public class StatusesEvaluationSystem : IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _data;

        public void StateUpdate()
        {
            foreach (var status in _data.Statuses)
            {
                status.Tick(Time.deltaTime);
            }
        }
    }
}