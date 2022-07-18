using alicewithalex.Configs;
using NoName.Data;
using System.Collections.Generic;
using UnityEngine;

namespace alicewithalex.Data
{
    public class GameStateData : StateData
    {
        public Player Player;
        public FirstPersonCamera Camera;

        public GameInput Input;
        public Enemy Enemy;

        public Inventory Inventory;

        public List<Hand> Hands = new List<Hand>(2);
        public Dictionary<Transform, Pickup> Pickups = new Dictionary<Transform, Pickup>();

        public List<Projectile> Projectiles = new List<Projectile>();
        public List<Status> Statuses = new List<Status>();

        public InputConfig InputConfig;
        public MotionConfig MovementConfig;
        public MouseConfig MouseConfig;
        public InteractionConfig InteractionConfig;


        private Transform _cameraTransform;

        public Ray Look
        {
            get
            {
                if (!_cameraTransform)
                    _cameraTransform = Camera.transform;

                return new Ray(_cameraTransform.position, _cameraTransform.forward);
            }
        }
    }
}