using alicewithalex.Configs;
using NoName.Data;
using System.Collections.Generic;
using UnityEngine;

namespace alicewithalex.Data
{
    public class GameStateData : StateData
    {
        public Player Player;
        public GameInput Input;

        public Inventory Inventory;
        public List<Hand> Hands = new List<Hand>(2);

        public InputConfig InputConfig;
        public MouseConfig MouseConfig;
        public PickupConfig PickupConfig;

        public Dictionary<Transform, Pickable> Pickables = new Dictionary<Transform, Pickable>();
    }
}