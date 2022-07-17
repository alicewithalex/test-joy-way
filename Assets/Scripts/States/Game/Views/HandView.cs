using alicewithalex.Data;
using NoName.StateMachine;
using System.Collections.Generic;
using UnityEngine;

namespace alicewithalex.Views
{
    public class HandView : ViewComponent<GameStateData>
    {
        [SerializeField] private SlotType _slotType;
        [SerializeField] private List<Item> _items = new List<Item>();

        public override State State => State.Game;

        protected override void Process(GameStateData stateData)
        {
            stateData.Hands.Add(new Hand(_slotType, _items));
        }
    }
}