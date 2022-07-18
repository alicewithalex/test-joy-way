using NoName.Interfaces;
using UnityEngine;

namespace alicewithalex.Data
{
    public abstract class Item : StateDataReciever<GameStateData>
    {
        [SerializeField] private ItemType _itemType;

        private Hand _hand;

        public ItemType ItemType => _itemType;
        public Hand Hand => _hand;

        public void Arm(Hand hand)
        {
            _hand = hand;
            Toggle(true);
        }
        public void Disarm()
        {
            _hand = null;
            Toggle(false);
        }

        protected void Toggle(bool value) => gameObject.SetActive(value);

        public abstract void Interact();
    }
}