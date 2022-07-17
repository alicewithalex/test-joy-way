using System;
using UnityEngine;

namespace alicewithalex.Events
{
    public class TriggerListener : MonoBehaviour
    {
        public event Action<Transform, Collider> TriggerEnter;
        public event Action<Transform, Collider> TriggerStay;
        public event Action<Transform, Collider> TriggerExit;

        private void OnTriggerEnter(Collider other)
        {
            TriggerEnter?.Invoke(transform, other);
        }

        private void OnTriggerStay(Collider other)
        {
            TriggerStay?.Invoke(transform, other);
        }

        private void OnTriggerExit(Collider other)
        {
            TriggerExit?.Invoke(transform, other);
        }
    }
}