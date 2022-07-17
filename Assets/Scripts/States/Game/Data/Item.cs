using UnityEngine;

namespace alicewithalex.Data
{
    public class Item
    {
        public readonly ItemType ItemType;
        public readonly Transform Transform;

        public Item(ItemType itemType, Transform transform)
        {
            ItemType = itemType;
            Transform = transform;
        }

        public void Show() => Transform.gameObject.SetActive(true);
        public void Hide() => Transform.gameObject.SetActive(false);
    }
}