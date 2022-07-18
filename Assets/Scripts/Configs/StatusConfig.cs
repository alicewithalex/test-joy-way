using alicewithalex.Data;
using alicewithalex.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace alicewithalex.Configs
{
    [CreateAssetMenu(menuName = "Configs/Status Config")]
    public class StatusConfig : ScriptableObject
    {
        public StatusType StatusType;
        [Min(0)] public float Duration;

        [Space(4)]
        [Min(0)] public float Amount;
        [Min(0)] public float Damage;
        [Min(0)] public int Ticks;

        [Space(4)]
        public List<DamageModifier> DamageModifiers = new List<DamageModifier>();
    }
}