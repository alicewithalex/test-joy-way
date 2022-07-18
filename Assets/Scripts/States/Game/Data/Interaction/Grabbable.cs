
using UnityEngine;

namespace alicewithalex.Data
{
    public class Grabbable : Pickup
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField, Min(0)] private float _force;
        [SerializeField, Min(0)] private float _upwardForce;

        protected bool _grabbed;

        public override bool Interactable => !_grabbed;

        public override void Interact()
        {
            if (!Interactable) return;

            ClearVelocity();
            _grabbed = true;
        }

        public override void Release()
        {
            if (_rigidbody)
            {
                _rigidbody.AddForce(_rigidbody.transform.forward * _force +
                    _rigidbody.transform.up * _upwardForce, ForceMode.Impulse);
            }

            _grabbed = false;
        }

        public override void OnReset()
        {
            ClearVelocity();
            _grabbed = false;

            base.OnReset();
        }

        private void ClearVelocity()
        {
            if (_rigidbody)
            {
                _rigidbody.velocity = _rigidbody.angularVelocity = Vector3.zero;
            }
        }
    }
}