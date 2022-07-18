using alicewithalex.Configs;
using NoName.Data;
using System.Collections.Generic;
using UnityEngine;

namespace alicewithalex.Data
{
    public class GameStateData : StateData
    {
        public Player Player;
        public Camera Camera;
        public GameInput Input;

        public Enemy Enemy;

        public Inventory Inventory;
        public List<Hand> Hands = new List<Hand>(2);

        public InputConfig InputConfig;
        public MovementConfig MovementConfig;
        public MouseConfig MouseConfig;
        public PickupConfig PickupConfig;

        public Dictionary<Transform, Pickable> Pickables = new Dictionary<Transform, Pickable>();
    }
}