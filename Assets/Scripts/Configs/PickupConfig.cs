using UnityEngine;

namespace alicewithalex.Configs
{
    [CreateAssetMenu(menuName = "Configs/Pickup Config")]
    public class PickupConfig : ScriptableObject
    {
        [Header("Core")]
        [Range(0f,16f)] public float PickupDistance = 2.5f;
        public LayerMask PickupLayer;
    }
}