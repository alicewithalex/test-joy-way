using alicewithalex.Configs;
using alicewithalex.Interfaces;
using UnityEngine;

namespace alicewithalex.Data
{
    public class Weapon : Item
    {
        [Space(4)]
        [SerializeField] private ProjectileConfig _projectileConfig;
        [SerializeField] private StatusConfig _statusConfig;
        [SerializeField] private Transform _origin;

        public override void Interact()
        {
            if (!_projectileConfig) return;

            var projectile = new Projectile(_origin ? _origin : transform, Data.Look,
                _projectileConfig);

            projectile.OnProjectileHitsTarget += HitTarget;
            projectile.OnProjectileVanished += DestroyProjectile;

            Data.Projectiles.Add(projectile);
        }

        private void DestroyProjectile(Projectile projectile)
        {
            Data.Destroy(projectile);
        }

        private void HitTarget(Transform target)
        {
            if (!target.TryGetComponent<HitBox>(out var hitBox)) return;

            hitBox.Target.Damage(_projectileConfig.Damage * hitBox.DamagePercentage);

            var status = CreateStatus(hitBox.Target, _statusConfig);

            if (status != null)
            {
                hitBox.Target.Refresh(status);
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
                    status = new FireStatus(target, config.Amount, config.Damage, config.Ticks, config.Duration);
                    break;
                case StatusType.Wet:
                    status = new WetStatus(target, config.Amount, config.Damage, config.Ticks, config.Duration);
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