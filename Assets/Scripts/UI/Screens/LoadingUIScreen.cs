using NoName.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace alicewithalex.UI
{
    public class LoadingUIScreen : UIScreen
    {
        [Header("Inheritance")]
        [SerializeField] private CanvasGroup _progressGroup;
        [SerializeField] private Image _progress;
        [SerializeField] private TextMeshProUGUI _progressText;

        public void UpdateProgress(float normalizedValue)
        {
            _progress.fillAmount = normalizedValue;
            _progressText.text = $"{(normalizedValue * 100).ToString("0.0")}%";
        }

        public void ToggleProgress(bool value)
        {
            Toggle(_progressGroup, value);
        }
    }
}