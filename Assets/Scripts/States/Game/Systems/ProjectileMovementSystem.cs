using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;
using UnityEngine;

namespace alicewithalex.Systems
{
    public class ProjectileMovementSystem : IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _data;

        public void StateUpdate()
        {
            foreach (var projectile in _data.Projectiles)
            {
                projectile.Track(Time.deltaTime);
            }
        }
    }
}