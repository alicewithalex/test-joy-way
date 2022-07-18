using NoName.Interfaces;
using UnityEngine;

namespace alicewithalex.Data
{
    public abstract class Item : StateDataReciever<GameStateData>
    {
        [SerializeField] private ItemType _itemType;
        [SerializeField] private KeyUsage _keyUsage;

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

        public abstract void Interact(KeyCode key);

        public bool IsUsing(KeyCode key)
        {
            switch (_keyUsage)
            {
                default:
                case KeyUsage.None:
                    return false;
                case KeyUsage.Pressed:
                    return Input.GetKeyDown(key);
                case KeyUsage.Held:
                    return Input.GetKey(key);
                case KeyUsage.Released:
                    return Input.GetKeyUp(key);

            }
        }
    }
}