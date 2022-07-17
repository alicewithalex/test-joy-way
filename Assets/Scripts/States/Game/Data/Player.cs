
using alicewithalex.Configs;
using UnityEngine;

namespace alicewithalex.Data
{
    public class Player
    {
        private readonly CharacterController _characterController;
        private readonly Transform _transform;
        private readonly Transform _camera;

        private readonly MovementConfig _config;

        private float _currentSpeed;

        private float _verticalVelocity;
        private Vector3 _velocity;

        private float _xRot;
        private float _yRot;

        public Pickable LookAt;

        public Ray LookRay => new Ray(_camera.position, _camera.forward);

        public Player(CharacterController characterController, Transform camera, MovementConfig config)
        {
            _characterController = characterController;
            _camera = camera;
            _config = config;
            _transform = _characterController.transform;
        }


        public void AddRotation(Vector2 mouseInput, float sensitivity, float minPitch, float maxPitch)
        {
            _xRot -= mouseInput.x * sensitivity;
            _yRot += mouseInput.y * sensitivity;

            _xRot = Mathf.Clamp(_xRot, minPitch, maxPitch);

            _transform.localEulerAngles = new Vector3(0f, _yRot, 0f);
            _camera.localEulerAngles = new Vector3(_xRot, 0f, 0f);
        }

        public void AddGravity(float deltaTime)
        {
            _verticalVelocity -= deltaTime * _config.Gravity;
        }

        public void Jump()
        {
            if (!_characterController.isGrounded) return;
            _verticalVelocity = Mathf.Sqrt(2 * _config.Gravity * _config.JumpForce);
        }

        public void AddMovement(Vector2 inputDirection, float deltaTime)
        {
            _currentSpeed = Mathf.Lerp(_currentSpeed, inputDirection.magnitude * _config.MovementSpeed,
                _config.MovementSmoothness * deltaTime);

            _velocity = _transform.TransformDirection(new Vector3(inputDirection.x, 0f, inputDirection.y)) * _currentSpeed;
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