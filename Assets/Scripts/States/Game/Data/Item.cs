using UnityEngine;

namespace alicewithalex.Data
{
    [System.Serializable]
    public class Item
    {
        [SerializeField] private ItemType _itemType;
        [SerializeField] private Transform _transform;

        public ItemType ItemType => _itemType;
        public Transform Transform => _transform;

        public Item(ItemType itemType, Transform transform)
        {
            _itemType = itemType;
            _transform = transform;
        }

        public Pickable Pickable;

        public void Show() => Transform.gameObject.SetActive(true);
        public void Hide() => Transform.gameObject.SetActive(false);
    }
}