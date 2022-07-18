using NoName.Interfaces;
using UnityEngine;

namespace alicewithalex.Data
{
    public abstract class Pickup : StateDataReciever<GameStateData>
    {
        [SerializeField] private ItemType _itemType;

        private Transform _transform;

        public ItemType ItemType => _itemType;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            _transform = transform;
            Data.Pickups.Add(_transform, this);
        }

        public abstract void Interact();

        public abstract void Release();

        public abstract bool Interactable { get; }

        public void Toggle(bool value) => gameObject.SetActive(value);
    }
}