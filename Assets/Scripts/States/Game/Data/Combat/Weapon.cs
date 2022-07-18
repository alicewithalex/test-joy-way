using alicewithalex.Configs;
using alicewithalex.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace alicewithalex.Data
{
    public class Weapon : Item
    {
        const float DEFAULT_FAR_DISTANCE = 100f;

        [Space(4)]
        [SerializeField] protected ProjectileConfig _projectileConfig;
        [SerializeField] protected StatusConfig _statusConfig;
        [SerializeField] protected Transform _origin;

        [SerializeField] private UnityEvent _onInteract;

        public override void Interact(KeyCode key)
        {
            if (!IsUsing(key) || !_projectileConfig) return;

            var projectile = new Projectile(Origin, ProjectileDirection(), _projectileConfig);

            projectile.OnProjectileHitsTarget += OnHitTarget;
            projectile.OnProjectileVanished += DestroyProjectile;

            _onInteract?.Invoke();

            Data.Projectiles.Add(projectile);
        }

        protected Transform Origin => _origin ? _origin : transform;

        protected Vector3 ProjectilePoint()
        {
            var ray = Data.Look;
            var point = ray.GetPoint(DEFAULT_FAR_DISTANCE);
            if (Physics.Raycast(ray, out var hit, DEFAULT_FAR_DISTANCE * 2f, _projectileConfig.Layer,
                QueryTriggerInteraction.Collide))
            {
                point = hit.point;
            }

            return point;
        }

        protected Vector3 ProjectileDirection()
        {
            return (ProjectilePoint() - _origin.position).normalized;
        }

        protected void DestroyProjectile(Projectile projectile)
        {
            Data.Destroy(projectile);
        }

        public void OnHitTarget(Transform target)
        {
            if (!target.TryGetComponent<HitBox>(out var hitBox)) return;

            hitBox.Target.Damage(_projectileConfig.Damage * hitBox.DamagePercentage, _projectileConfig.Modifiable);

            var status = CreateStatus(hitBox.Target, _statusConfig);

            if (status != null)
            {
                if (hitBox.Target.Refresh(status))
                    Data.Statuses.Add(status);
            }
        }

        private Status CreateStatus(IDamagable target, StatusConfig config)
        {
            if (!config) return null;

            Status status = null;

            switch (config.StatusType)
            {
                default:
                case StatusType.None:
                    break;

                case StatusType.OnFire:
                    status = new FireStatus(target, _statusConfig.DamageModifiers, config.Amount,
                        config.Damage, config.Ticks, config.Duration);
                    break;
                case StatusType.Wet:
                    status = new WetStatus(target, _statusConfig.DamageModifiers, config.Amount,
                        config.Damage, config.Ticks, config.Duration);
                    break;
            }

            if (status != null)
            {
                status.OnStatusEnded += DestroyStatus;
            }

            return status;
        }

        private void DestroyStatus(Status status)
        {
            Data.Destroy(status);
        }
    }
}