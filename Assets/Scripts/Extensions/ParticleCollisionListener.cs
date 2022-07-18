using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace alicewithalex.Listeners
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ParticleCollisionListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent<Transform> _onParticleCollided;

        public event Action<Transform> OnParticleCollided;

        private void OnParticleCollision(GameObject other)
        {
            _onParticleCollided?.Invoke(other.transform);
            OnParticleCollided?.Invoke(other.transform);
        }
    }
}