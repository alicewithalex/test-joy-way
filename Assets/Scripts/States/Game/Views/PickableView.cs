using alicewithalex.Data;
using NoName.StateMachine;
using UnityEngine;

namespace alicewithalex.Views
{
    public class PickableView : ViewComponent<GameStateData>
    {
        [SerializeField] private ItemType _itemType;

        public override State State => State.Game;

        protected override void Process(GameStateData stateData)
        {
            stateData.Pickables.Add(transform, new Pickable(_itemType, transform));
        }
    }
}