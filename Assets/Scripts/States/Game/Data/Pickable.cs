using UnityEngine;

namespace alicewithalex.Data
{
    public class Pickable
    {
        public readonly ItemType PickupType;
        public readonly Transform Transform;

        public Pickable(ItemType pickupType, Transform transform)
        {
            PickupType = pickupType;
            Transform = transform;
        }

        public bool Obtainable;

    }
}