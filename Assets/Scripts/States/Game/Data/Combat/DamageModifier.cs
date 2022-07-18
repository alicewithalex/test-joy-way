using UnityEngine;

namespace alicewithalex.Data
{
    [System.Serializable]
    public class DamageModifier
    {
        [SerializeField] private DamageModifierType _type;
        [SerializeField] private float _value;

        public float Modify(float damage)
        {
            switch (_type)
            {
                case DamageModifierType.Flat:
                    return damage + _value;
                case DamageModifierType.Percent:
                    return damage * _value;
                default: return damage;
            }
        }
    }
}