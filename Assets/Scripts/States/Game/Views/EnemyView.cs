using alicewithalex.Data;
using alicewithalex.Events;
using NoName.StateMachine;
using System.Collections.Generic;
using UnityEngine;

namespace alicewithalex.Views
{
    public class EnemyView : ViewComponent<GameStateData>
    {
        [SerializeField, Min(0)] private float _health;
        [SerializeField] private List<TriggerListener> _hitBoxes;

        public override State State => State.Game;

        protected override void Process(GameStateData stateData)
        {
            stateData.Enemy = new Enemy(_health, _hitBoxes, "Projectile");
        }
    }
}