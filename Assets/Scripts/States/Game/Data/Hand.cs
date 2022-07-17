using System.Collections.Generic;
using System.Linq;

namespace alicewithalex.Data
{
    public class Hand
    {
        public readonly SlotType SlotType;

        private readonly Dictionary<ItemType, Item> _items;

        public Hand(SlotType slotType, List<Item> items)
        {
            SlotType = slotType;
            _items = items.ToDictionary(x => x.ItemType);
        }

        public Item GetItem(ItemType itemType)
        {
            if (_items.ContainsKey(itemType))
            {
                return _items[itemType];
            }

            return null;
        }
    }
}