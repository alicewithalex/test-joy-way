using UnityEngine;

namespace alicewithalex.Configs
{
    [CreateAssetMenu(menuName = "Configs/Pickup Config")]
    public class InteractionConfig : ScriptableObject
    {
        [Range(0f,16f)] public float Distance = 2.5f;
        public LayerMask Layer;
    }
}