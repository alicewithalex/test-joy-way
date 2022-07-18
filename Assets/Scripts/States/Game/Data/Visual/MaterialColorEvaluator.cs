using UnityEngine;

namespace alicewithalex.Listeners
{
    public class MaterialColorEvaluator : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private string _propertyName = "_Color";

        [SerializeField] private Color _color1, _color2;

        private int? _id;

        public int ID
        {
            get
            {
                if (_id is null)
                    _id = Shader.PropertyToID(_propertyName);

                return _id.Value;
            }
        }

        public void OnValueChanged(float value)
        {
            if (!_renderer) return;

            _renderer.material.SetColor(ID, Color.Lerp(_color1, _color2, Mathf.Clamp01(value)));
        }
    }
}