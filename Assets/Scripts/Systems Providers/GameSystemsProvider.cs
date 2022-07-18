using alicewithalex.Data;
using NoName.Providers;
using NoName.Systems;

namespace alicewithalex
{
    public class GameSystemsProvider : StateSystemsProvider<GameStateData>
    {
        protected override void Process(StateSystems systems, IContainer container)
        {
            systems

                .Add(new Systems.GameStateInitializeSystem())

                .Add(new Systems.PlayerCameraSystem())
                .Add(new Systems.PlayerMotionSystem())
                .Add(new Systems.PlayerSearchSystem())

                .Add(new Systems.PlayerInteractionSystem())
                .Add(new Systems.PlayerDropSystem())

                .Add(new Systems.PlayerShootSystem())
                .Add(new Systems.ProjectileMovementSystem())
                .Add(new Systems.StatusesEvaluationSystem())

                .Add(new Systems.ProjectileCleanupSystem())
                .Add(new Systems.StatusesCleanupSystem())

                .Add(new Systems.StateDataCleanupSystem<GameStateData>())

                ;
        }
    }
}