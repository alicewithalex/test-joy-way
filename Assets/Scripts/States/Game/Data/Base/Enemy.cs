using alicewithalex.Interfaces;
using NoName.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace alicewithalex.Data
{
    public class Enemy : StateDataReciever<GameStateData>, IDamagable, IResetable
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

                _onFireWaterPercentageChanged?.Invoke(Mathf.InverseLerp(-100f, 100f, _fireWaterPercentage));
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

        private Status _status;

        public event Action<Status> OnStatusStopped;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            OnReset();

            foreach (var hitbox in _hitBoxes)
                hitbox.Link(this);

            Data.Enemy = this;
            Data.Resetables.Add(this);
        }

        public void Damage(float amount, bool modifiable = false)
        {
            if (_status != null && modifiable)
                amount = _status.Modify(amount);

            Health -= amount;
        }

        public bool Refresh(Status status)
        {
            FireWaterPercentage += status.Sign * status.Amount;

            var affected = status.IsAffected(FireWaterPercentage);
            var negating = status.IsNegating(_status);

            if (negating)
            {
                ClearStatus();
                return false;
            }
            else
            {
                if (affected)
                {
                    ClearStatus();
                    _status = status;
                    _status.OnStatusEnded += RemoveStatus;
                }
                else if (FireWaterPercentage == 0)
                {
                    ClearStatus();
                    _status = null;
                }

                return affected;
            }
        }

        private void ClearStatus()
        {
            if (_status is null) return;

            OnStatusStopped?.Invoke(_status);
        }

        private void RemoveStatus(Status status) => _status = null;

        public void OnReset()
        {
            Health = _maxHealth = _health;
            FireWaterPercentage = 0f;

            ClearStatus();
        }
    }
}