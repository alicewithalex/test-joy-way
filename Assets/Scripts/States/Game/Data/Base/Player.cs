using alicewithalex.Configs;
using NoName.Interfaces;
using UnityEngine;

namespace alicewithalex.Data
{
    public class Player : StateDataReciever<GameStateData>
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private MotionConfig _movementConfig;

        private Transform _transform;

        private float _currentSpeed;
        private float _currentAngle;
        private float _verticalVelocity;
        private Vector3 _velocity;

        public Transform TargetItem { get; private set; }

        protected override void OnInitialize()
        {
            Data.Player = this;

            _transform = transform;
        }

        public void Move()
        {
            var direction = Data.Input.Movement.normalized;
            _currentSpeed = Mathf.Lerp(_currentSpeed, direction.magnitude * _movementConfig.MovementSpeed,
                Time.deltaTime * _movementConfig.MovementSmoothness);

            _velocity = _transform.TransformDirection(new Vector3(direction.x, 0f, direction.y)) * _currentSpeed;
        }

        public void Rotate()
        {
            _currentAngle += Data.Input.Look.y * Data.MouseConfig.MouseSensitivity;
        }

        public void Gravity()
        {
            _verticalVelocity -= _movementConfig.Gravity * Time.deltaTime;
        }

        public void Jump()
        {
            if (!_characterController.isGrounded) return;

            _verticalVelocity = Mathf.Sqrt(2 * _movementConfig.Gravity * _movementConfig.JumpForce);
        }

        public void Search()
        {
            if (!Physics.Raycast(Data.Look, out var hit, Data.InteractionConfig.Distance, Data.InteractionConfig.Layer,
                QueryTriggerInteraction.Collide))
            {
                TargetItem = null;
                return;
            }

            if (TargetItem != hit.transform)
                TargetItem = hit.transform;
        }

        public void Execute()
        {
            _transform.localEulerAngles = new Vector3(0, _currentAngle, 0);

            _characterController.Move((_velocity + Vector3.up * _verticalVelocity) * Time.deltaTime);

            _velocity = Vector3.zero;

            if (_characterController.isGrounded)
            {
                _verticalVelocity = 0f;
            }
        }
    }
}