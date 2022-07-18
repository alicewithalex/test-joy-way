using NoName.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace alicewithalex.Data
{
    public class Hand : StateDataReciever<GameStateData>
    {
        [SerializeField] private HandType _handType;
        [SerializeField] private List<Item> _possibleItems;

        private Dictionary<ItemType, Item> _items;
        private Pickup _pickup;
        private Item _current;

        private bool _justPicked;

        public HandType HandType => _handType;

        public bool IsHolding => _pickup != null;

        public bool JustPicked
        {
            get
            {
                if (_justPicked)
                {
                    _justPicked = false;
                    return true;
                }

                return false;
            }
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            Initialize();

            Data.Hands.Add(this);
        }

        private void Initialize()
        {
            _items = _possibleItems.ToDictionary(x => x.ItemType);

            foreach (var item in _items.Values)
                item.Disarm();
        }

        public void Use(KeyCode key)
        {
            if (!_current) return;

            _current.Interact(key);
        }

        public void Grab(Pickup pickup)
        {
            _justPicked = true;
            _pickup = pickup;
            _pickup.Toggle(false);

            _current = _items[_pickup.ItemType];
            _current.Arm(this);
        }

        public Pickup Release()
        {
            if (!_pickup || !_current) return null;

            var pickup = _pickup;

            _current.Disarm();
            _pickup.Toggle(true);

            _current = null;
            _pickup = null;

            return pickup;
        }
    }
}