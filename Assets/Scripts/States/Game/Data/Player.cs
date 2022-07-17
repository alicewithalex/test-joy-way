
using alicewithalex.Configs;
using UnityEngine;

namespace alicewithalex.Data
{
    public class Player
    {
        private readonly CharacterController _characterController;
        private readonly Transform _transform;
        private readonly Transform _camera;

        private readonly LocomotionConfig _locomotionConfig;

        private float _currentSpeed;
        private float _currentSpeedVelocity;

        private float _verticalVelocity;
        private Vector3 _velocity;

        private float _xRot;
        private float _yRot;

        public Pickable Pickable;

        public Player(CharacterController characterController, Transform camera, LocomotionConfig locomotionConfig)
        {
            _characterController = characterController;
            _camera = camera;
            _locomotionConfig = locomotionConfig;

            _transform = _characterController.transform;
        }


        public void ApplyRotation(Vector2 mouseInput, float deltaTime)
        {
            _xRot -= mouseInput.x * _locomotionConfig.MouseSensitivity;
            _yRot += mouseInput.y * _locomotionConfig.MouseSensitivity;

            _xRot = Mathf.Clamp(_xRot, _locomotionConfig.MinPitch, _locomotionConfig.MaxPitch);

            _transform.localEulerAngles = new Vector3(0f, _yRot, 0f);
            _camera.localEulerAngles = new Vector3(_xRot, 0f, 0f);
        }

        public void ApplyGravity(float deltaTime)
        {
            _verticalVelocity -= deltaTime * _locomotionConfig.Gravity;
        }

        public void Jump()
        {
            if (!_characterController.isGrounded) return;
            _verticalVelocity = Mathf.Sqrt(2 * _locomotionConfig.Gravity * _locomotionConfig.JumpForce);
        }

        public void ApplyMovement(Vector2 direction, float deltaTime)
        {
            _currentSpeed = Mathf.Lerp(_currentSpeed, direction.magnitude * _locomotionConfig.MovementSpeed,
                _locomotionConfig.MovementSmoothness * deltaTime);

            _velocity = _transform.TransformDirection(new Vector3(direction.x, 0f, direction.y)) * _currentSpeed;
        }

        public void Evaluate(float deltaTime)
        {
            _characterController.Move((_velocity + Vector3.up * _verticalVelocity) * deltaTime);

            _velocity = Vector3.zero;

            if (_characterController.isGrounded)
                _verticalVelocity = 0f;
        }
    }
}