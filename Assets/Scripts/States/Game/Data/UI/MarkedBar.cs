using UnityEngine;

namespace alicewithalex.Data
{
    public class MarkedBar : MonoBehaviour
    {
        [SerializeField] private RectTransform _marker;
        [SerializeField] private float _min;
        [SerializeField] private float _max;

        public void OnValueChanged(float normalizedValue)
        {
            if (!_marker) return;

            _marker.anchoredPosition = Vector2.right * Mathf.Lerp(_min, _max, normalizedValue);
        }
    }
}