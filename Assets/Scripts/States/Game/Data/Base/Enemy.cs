using alicewithalex.Interfaces;
using NoName.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace alicewithalex.Data
{
    public class Enemy : StateDataReciever<GameStateData>, IDamagable
    {
        [SerializeField, Min(0)] private float _health = 1000f;
        [SerializeField] private List<HitBox> _hitBoxes = new List<HitBox>();

        [SerializeField] private UnityEvent<float> _onFireWaterPercentageChanged;
        [SerializeField] private UnityEvent<float> _onHealthChanged;

        private float _maxHealth;
        private float _currentHealth;
        private float _fireWaterPercentage;

        private float FireWaterPercentage
        {
            get => _fireWaterPercentage;
            set
            {
                _fireWaterPercentage = Mathf.Clamp(value, -100f, 100f);

                _onFireWaterPercentageChanged?.Invoke((_fireWaterPercentage + 100) * 0.01f);
            }
        }

        private float Health
        {
            get => _currentHealth;
            set
            {
                _currentHealth = Mathf.Clamp(value, 0, _maxHealth);

                float percentage = _maxHealth == 0 ? 0 : _currentHealth / _maxHealth;
                _onHealthChanged?.Invoke(percentage);
            }
        }

        private StatusType _statusType;
        private Status _status;

        public event Action<Status> OnStatusStopped;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            Health = _maxHealth = _health;

            foreach (var hitbox in _hitBoxes)
                hitbox.Link(this);

            Data.Enemy = this;
        }

        public void Damage(float amount)
        {
            Health -= amount;

            float percentage = _maxHealth == 0 ? 0 : _currentHealth / _maxHealth;
            _onHealthChanged?.Invoke(percentage);
        }

        public bool Refresh(Status status)
        {
            if (_statusType.Equals(status.Negate))
            {
                FireWaterPercentage += status.Sign * status.Amount;
            }

            bool affected = status.IsAffected(FireWaterPercentage);

            if (affected)
            {
                _statusType = status.Type;

                if (_status != null)
                    OnStatusStopped?.Invoke(_status);

                _status = status;
            }
            else
            {
                _statusType = StatusType.None;
                _status = null;
            }

            return affected;
        }

    }
}