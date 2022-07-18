using alicewithalex.Configs;
using UnityEngine;

namespace alicewithalex.Data
{
    public class GameInput
    {
        private readonly InputConfig _inputConfig;
        private int _leftHandPressedFrame;
        private int _rightHandPressedFrame;

        public GameInput(InputConfig inputConfig)
        {
            _inputConfig = inputConfig;
        }

        public Vector2 Movement => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        public Vector2 Look => new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));

        public bool LeftHandPressed
        {
            get
            {
                return Input.GetKeyDown(_inputConfig.LeftHandGrab);

                var pressed = Input.GetKeyDown(_inputConfig.LeftHandGrab);

                if (pressed && Time.frameCount > _leftHandPressedFrame)
                {
                    _leftHandPressedFrame = Time.frameCount;
                    return true;
                }

                return false;
            }
        }

        public bool RightHandPressed 
        {
            get
            {
                return Input.GetKeyDown(_inputConfig.RightHandGrab);


                var pressed = Input.GetKeyDown(_inputConfig.RightHandGrab);

                if (pressed && Time.frameCount > _rightHandPressedFrame)
                {
                    _rightHandPressedFrame = Time.frameCount;
                    return true;
                }

                return false;
            }
        }

        public bool JumpPressed => Input.GetKeyDown(_inputConfig.Jump);
    }
}