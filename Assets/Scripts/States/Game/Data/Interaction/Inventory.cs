using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace alicewithalex.Data
{
    public class Inventory
    {
        private readonly Dictionary<HandType, Hand> _hands;

        public Inventory(List<Hand> hands)
        {
            _hands = hands.ToDictionary(x => x.HandType);
        }

        public bool IsHolding(HandType handType) => _hands.ContainsKey(handType) && _hands[handType].IsHolding;

        public bool Add(HandType handType, Pickup item)
        {
            if (IsHolding(handType) || !item.Interactable) return false;

            _hands[handType].Grab(item);

            return true;
        }

        public Pickup Remove(HandType handType)
        {
            if (!_hands.TryGetValue(handType, out var hand)) return null;

            return hand.Release();
        }

        public void UseItem(HandType handType,KeyCode key)
        {
            if (!IsHolding(handType)) return;

            _hands[handType].Use(key);
        }
    }
}