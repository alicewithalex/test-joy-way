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

        public bool LeftHandHolding => Input.GetKey(_inputConfig.LeftHandGrab);
        public bool RightHandHolding => Input.GetKey(_inputConfig.RightHandGrab);

        public bool JumpPressed => Input.GetKeyDown(_inputConfig.Jump);

        public bool LeftHandShoot => Input.GetKeyDown(_inputConfig.LeftHandShoot);
        public bool RightHandShoot => Input.GetKeyDown(_inputConfig.RightHandShoot);
    }
}