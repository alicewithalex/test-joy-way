using UnityEngine;

namespace alicewithalex.Configs
{
    [CreateAssetMenu(menuName = "Configs/Input Config")]
    public class InputConfig : ScriptableObject
    {

        [Header("Keys")]
        public KeyCode LeftHandGrab = KeyCode.Q;
        public KeyCode RightHandGrab = KeyCode.E;

        [Space(8)]
        public KeyCode LeftHandShoot = KeyCode.Mouse0;
        public KeyCode RightHandShoot = KeyCode.Mouse1;

        [Space(8)]
        public KeyCode Jump = KeyCode.Space;
    }
}