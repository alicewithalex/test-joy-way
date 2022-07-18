using NoName.Interfaces;
using UnityEngine;

namespace alicewithalex.Data
{
    public class FirstPersonCamera : StateDataReciever<GameStateData>
    {
        private float _rotation;
        private Transform _transform;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            _transform = transform;
            Data.Camera = this;
        }

        public void Tick()
        {
            _rotation -= Data.Input.Look.x * Data.MouseConfig.MouseSensitivity;
            _rotation = Mathf.Clamp(_rotation, Data.MouseConfig.MinPitch, Data.MouseConfig.MaxPitch);

            _transform.localEulerAngles = new Vector3(_rotation, 0f, 0f);
        }
    }
}