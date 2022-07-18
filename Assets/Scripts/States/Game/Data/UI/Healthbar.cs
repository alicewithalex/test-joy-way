using UnityEngine;
using UnityEngine.UI;

namespace alicewithalex.Data
{
    public class Healthbar : MonoBehaviour
    {
        [SerializeField] private Image _fillImage;

        public void OnHealthChanged(float normalizedValue)
        {
            if (!_fillImage) return;

            _fillImage.fillAmount = normalizedValue;
        }
    }
}