using UnityEngine;

namespace alicewithalex.Configs
{
    [CreateAssetMenu(menuName = "Configs/Locomotion Config")]
    public class LocomotionConfig : ScriptableObject
    {
        [Header("Movement")]
        [Range(0f, 32f)] public float MovementSpeed = 7.5f;
        [Range(0f, 32f)] public float MovementSmoothness = 10f;

        [Header("Gravity")]
        [Range(0f, 32f)] public float Gravity = 9.81f;
        [Range(0f, 128f)] public float JumpForce = 20f;

        [Header("Mouse Input")]
        [Range(0.25f, 3f)] public float MouseSensitivity = 1.5f;
        [Space(4)]
        [Range(-180, 180)] public float MinPitch = -30f;
        [Range(-180, 180)] public float MaxPitch = 70f;
    }
}