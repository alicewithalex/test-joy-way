using UnityEngine;

namespace alicewithalex.Data
{
    [System.Serializable]
    public class Item
    {
        public ItemType ItemType;
        public Transform Transform;

        public Pickable Pickable;
    }
}