using alicewithalex.Interfaces;
using System;

namespace alicewithalex.Data
{
    public abstract class Status
    {
        public abstract StatusType Type { get; }
        public readonly ITarget Target;

        private readonly float _value;
        private readonly float _delay;

        private float _tick;
        private float _duration;
        private bool _ended;

        public event Action<Status> OnStatusEnded;

        public Status(ITarget target, float value, float delay, float lifeTime)
        {
            Target = target;

            _value = value;
            _delay = delay;
            _duration = lifeTime;
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

                Target.Damage(_value);
            }
        }
    }
}