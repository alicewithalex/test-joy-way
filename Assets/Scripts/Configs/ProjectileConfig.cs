using UnityEngine;

namespace alicewithalex.Configs
{
    [CreateAssetMenu(menuName = "Configs/Projectile Config")]
    public class ProjectileConfig : ScriptableObject
    {
        public Rigidbody Prefab;
        public LayerMask Layer;
        public bool Modifiable = false;

        [Space(4)]
        [Min(0)] public float Damage = 10;
        [Min(0)] public float Mass = 10;
        [Min(0)] public float Force = 100;
        public ForceMode ForceMode = ForceMode.Impulse;

        [Space(4)]
        [Min(0)] public float DestroyDelay = 5f;
    }
}