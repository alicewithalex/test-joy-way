using alicewithalex.Configs;
using System;
using UnityEngine;

namespace alicewithalex.Data
{
    public class Projectile
    {

        private readonly Rigidbody _rigidbody;
        private readonly LayerMask _layer;

        private Vector3 _previousPosition;
        private float _duration;

        public event Action<Transform> OnProjectileHitsTarget;
        public event Action<Projectile> OnProjectileVanished;

        public Projectile(Transform origin,Vector3 direction, ProjectileConfig projectileConfig)
        {
            _rigidbody = UnityEngine.Object.Instantiate(projectileConfig.Prefab);
            _layer = projectileConfig.Layer;

            _rigidbody.transform.position = origin.position;
            _rigidbody.transform.forward = direction;

            _rigidbody.mass = projectileConfig.Mass;
            _rigidbody.AddForce(_rigidbody.transform.forward * projectileConfig.Force, projectileConfig.ForceMode);

            _duration = projectileConfig.DestroyDelay;
        }

        public void Track(float deltaTime)
        {
            if (!Physics.Linecast(_previousPosition, _rigidbody.transform.position, out var hit, _layer,
                QueryTriggerInteraction.Collide))
            {
                _duration -= deltaTime;

                if (_duration <= 0)
                    OnProjectileVanished?.Invoke(this);

                return;
            }

            OnProjectileHitsTarget?.Invoke(hit.transform);
            OnProjectileVanished?.Invoke(this);
        }

        public void Destroy()
        {
            UnityEngine.Object.Destroy(_rigidbody.gameObject);
        }
    }
}