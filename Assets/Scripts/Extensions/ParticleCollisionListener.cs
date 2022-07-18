using System;
using UnityEngine;
using UnityEngine.Events;

namespace alicewithalex.Listeners
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ParticleCollisionListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent<GameObject> _onParticleCollided;

        public event Action<GameObject> OnParticleCollided;

        private void OnParticleCollision(GameObject other)
        {
            _onParticleCollided?.Invoke(other);
            OnParticleCollided?.Invoke(other);
        }
    }
}