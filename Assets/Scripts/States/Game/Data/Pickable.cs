using UnityEngine;

namespace alicewithalex.Data
{
    public class Pickable
    {
        public readonly ItemType ItemType;
        public readonly Transform Transform;

        public Pickable(ItemType pickupType, Transform transform)
        {
            ItemType = pickupType;
            Transform = transform;
        }

        public bool Obtainable;

    }
}