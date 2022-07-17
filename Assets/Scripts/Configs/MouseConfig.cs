using UnityEngine;

namespace alicewithalex.Configs
{
    [CreateAssetMenu(menuName = "Configs/Mouse Config")]
    public class MouseConfig : ScriptableObject
    {
        [Range(0.25f, 3f)] public float MouseSensitivity = 1.5f;

        [Space(4)]
        [Range(-180, 180)] public float MinPitch = -30f;
        [Range(-180, 180)] public float MaxPitch = 70f;
    }
}