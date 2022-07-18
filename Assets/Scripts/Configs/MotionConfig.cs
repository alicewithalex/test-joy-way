using UnityEngine;

namespace alicewithalex.Configs
{
    [CreateAssetMenu(menuName = "Configs/Movement Config")]
    public class MotionConfig : ScriptableObject
    {
        [Header("Movement")]
        [Range(0f, 32f)] public float MovementSpeed = 7.5f;
        [Range(0f, 32f)] public float MovementSmoothness = 10f;

        [Header("Gravity")]
        [Range(0f, 32f)] public float Gravity = 9.81f;
        [Range(0f, 128f)] public float JumpForce = 20f;

    }
}