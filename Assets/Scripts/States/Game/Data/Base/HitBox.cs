
using alicewithalex.Interfaces;
using UnityEngine;

namespace alicewithalex.Data
{
    public class HitBox : MonoBehaviour
    {
        [SerializeField, Range(0f, 2.5f)] private float _damagePercentage = 1f;

        public float DamagePercentage => _damagePercentage;
        public IDamagable Target { get; private set; }
        public void Link(IDamagable target)
        {
            if (Target is null) Target = target;
        }
    }
}