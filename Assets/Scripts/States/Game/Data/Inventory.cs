using NoName.Factory;
using System.Collections.Generic;
using System.Linq;

namespace alicewithalex.Data
{
    public class Inventory
    {
        private readonly Dictionary<SlotType, Item> _items;
        private readonly Dictionary<SlotType, Hand> _hands;

        public Inventory(List<Hand> hands)
        {
            _items = new Dictionary<SlotType, Item>();
            _hands = hands.ToDictionary(x => x.SlotType);
        }


        public bool IsHolding(SlotType slotType) => _items.ContainsKey(slotType);

        public bool HasHand(SlotType slotType) => _hands.ContainsKey(slotType);

        public ItemType GetItemType(SlotType slotType)
        {
            if (HasHand(slotType) && IsHolding(slotType))
            {
                return _items[slotType].ItemType;
            }
            else return ItemType.None;
        }

        public bool Add(SlotType slotType, Pickable pickable)
        {
            if (!HasHand(slotType) || IsHolding(slotType)) return false;

            _items.Add(slotType, _hands[slotType].GetItem(pickable.ItemType));

            if (_items[slotType] is null)
            {
                _items.Remove(slotType);
                return false;
            }

            _items[slotType].Pickable = pickable;
            _items[slotType].Transform.gameObject.SetActive(true);

            return true;
        }

        public Pickable Remove(SlotType slotType)
        {
            if (!HasHand(slotType) || (!IsHolding(slotType))) return null;

            var pickable = _items[slotType].Pickable;
            _items[slotType].Pickable = null;
            _items[slotType].Transform.gameObject.SetActive(false);
            _items.Remove(slotType);

            return pickable;
        }
    }
}