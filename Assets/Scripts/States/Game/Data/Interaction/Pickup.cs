using NoName.Interfaces;
using UnityEngine;

namespace alicewithalex.Data
{
    public abstract class Pickup : StateDataReciever<GameStateData>, IResetable
    {
        [SerializeField] private ItemType _itemType;

        private Vector3 _initialPosition;
        private Quaternion _initialRotation;
        private bool _activeSelf;

        private Transform _transform;

        public ItemType ItemType => _itemType;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            _transform = transform;

            _initialPosition = _transform.position;
            _initialRotation = _transform.rotation;
            _activeSelf = _transform.gameObject.activeSelf;

            Data.Pickups.Add(_transform, this);
        }

        public abstract void Interact();

        public abstract void Release();

        public abstract bool Interactable { get; }

        public void Toggle(bool value) => gameObject.SetActive(value);

        public virtual void OnReset()
        {
            _transform.position = _initialPosition;
            _transform.rotation = _initialRotation;
            _transform.gameObject.SetActive(_activeSelf);
        }
    }
}