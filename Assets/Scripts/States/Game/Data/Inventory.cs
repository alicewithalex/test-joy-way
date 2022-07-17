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

        public bool Add(SlotType slotType, ItemType itemType)
        {
            if (!HasHand(slotType) || IsHolding(slotType)) return false;

            _items.Add(slotType, _hands[slotType].GetItem(itemType));

            if (_items[slotType] is null)
            {
                _items.Remove(slotType);
                return false;
            }

            _items[slotType].Show();

            return true;
        }

        public bool Remove(SlotType slotType)
        {
            if (!HasHand(slotType) || (!IsHolding(slotType))) return false;

            _items[slotType].Hide();
            _items.Remove(slotType);

            return true;
        }
    }
}