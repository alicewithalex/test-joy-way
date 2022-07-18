using UnityEngine;

namespace alicewithalex.Data
{
    public class Player
    {
        public CharacterController CharacterController;
        public Transform Transform;

        public float CurrentSpeed;
        public float VerticalVelocity;
        public Vector3 Velocity;

        public float xRot;
        public float yRot;

        public Pickable LookingAt;
    }
}