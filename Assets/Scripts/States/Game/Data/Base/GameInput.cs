using alicewithalex.Configs;
using UnityEngine;

namespace alicewithalex.Data
{
    public class GameInput
    {
        private readonly InputConfig _inputConfig;

        public GameInput(InputConfig inputConfig)
        {
            _inputConfig = inputConfig;
        }

        public Vector2 Movement => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        public Vector2 Look => new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));

        public bool LeftHandPressed => Input.GetKeyDown(_inputConfig.LeftHandGrab);
        public bool RightHandPressed => Input.GetKeyDown(_inputConfig.RightHandGrab);

        public bool LeftHandReleased => Input.GetKeyUp(_inputConfig.LeftHandGrab);
        public bool RightHandReleased => Input.GetKeyUp(_inputConfig.RightHandGrab);

        public bool JumpPressed => Input.GetKeyDown(_inputConfig.Jump);

        public bool LeftHandShoot => Input.GetKeyDown(_inputConfig.LeftHandShoot);
        public bool RightHandShoot => Input.GetKeyDown(_inputConfig.RightHandShoot);
    }
}