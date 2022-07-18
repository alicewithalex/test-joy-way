using UnityEngine;

namespace alicewithalex.Data
{
    public class ParticleWeapon : Weapon
    {
        [SerializeField] protected ParticleSystem _effect;

        public override void Interact(KeyCode key)
        {
            if (!_projectileConfig || !_effect) return;

            if (IsUsing(key))
            {
                _effect.transform.forward = ProjectileDirection();

                if (!_effect.isPlaying)
                {
                    _effect.Play();
                }
            }
            else
            {
                _effect.Stop();
            }
        }

    }
}