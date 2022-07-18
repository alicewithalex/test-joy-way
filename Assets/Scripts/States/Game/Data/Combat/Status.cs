using alicewithalex.Interfaces;
using System;
using System.Collections.Generic;

namespace alicewithalex.Data
{
    public abstract class Status
    {
        public abstract StatusType Type { get; }
        public abstract StatusType Negate { get; }
        public abstract int Sign { get; }

        public readonly IDamagable Target;

        private readonly List<DamageModifier> _damageModifiers;

        private readonly float _amount;
        private readonly float _damage;
        private readonly float _delay;

        private float _tick;
        private float _duration;
        private bool _ended;

        public event Action<Status> OnStatusEnded;

        public float Amount => _amount;

        public Status(IDamagable target, List<DamageModifier> damageModifiers,
            float amount, float damage, int ticks = 3, float lifeTime = 2.0f)
        {
            Target = target;

            _amount = amount;
            _damage = damage;
            _duration = lifeTime;
            _damageModifiers = damageModifiers;

            if (ticks > 0)
            {
                _delay = lifeTime / ticks;
                _tick = _delay;
            }
            else _delay = 0f;

            if (_delay <= 0 || _duration <= 0)
            {
                _delay = _duration = 0f;
                _ended = true;
            }
        }

        public void Tick(float deltaTime)
        {
            if (_duration <= 0)
            {
                if (!_ended)
                {
                    OnStatusEnded?.Invoke(this);
                    _ended = true;
                }

                return;
            }

            _duration -= deltaTime;

            if (_tick > 0)
                _tick -= deltaTime;

            if (_tick <= 0)
            {
                _tick = _delay;
                Target.Damage(_damage);
            }
        }

        public abstract bool IsAffected(float value);

        public bool IsNegating(Status status)
        {
            if (status is null) return false;

            return Type.Equals(status.Negate);
        }

        public float Modify(float damage)
        {
            foreach (var modifer in _damageModifiers)
            {
                damage = modifer.Modify(damage);
            }

            return damage;
        }
    }
}