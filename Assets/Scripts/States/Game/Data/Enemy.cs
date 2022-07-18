using alicewithalex.Events;
using alicewithalex.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace alicewithalex.Data
{
    public class Enemy : ITarget
    {
        private float _health;

        public event Action<Enemy> OnEnemyDied;
        public event Action<Transform> OnHitted;

        private string _interactionTag;
        private bool _anyTag;

        public Enemy(float health, IList<TriggerListener> hitBoxes, string interactionTag = "")
        {
            _health = health;

            _interactionTag = interactionTag;
            _anyTag = string.IsNullOrEmpty(_interactionTag);

            foreach (var hitBox in hitBoxes)
            {
                hitBox.TriggerEnter += OnHit;
            }
        }

        public void OnHit(Transform self, Collider other)
        {
            if (!_anyTag || !other.CompareTag(_interactionTag)) return;

            OnHitted?.Invoke(other.transform);
        }

        public void Damage(float amount)
        {
            if (_health <= 0) return;

            _health -= amount;

            if (_health <= 0) OnEnemyDied?.Invoke(this);
        }
    }
}