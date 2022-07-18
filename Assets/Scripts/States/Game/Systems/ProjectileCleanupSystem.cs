using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;

namespace alicewithalex.Systems
{
    public class ProjectileCleanupSystem : IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _data;


        public void StateUpdate()
        {
            if (!_data.Exist<Projectile>(out var projectiles)) return;

            foreach (var projectile in projectiles)
            {
                _data.Projectiles.Remove(projectile);
                projectile.Destroy();
            }
        }
    }
}