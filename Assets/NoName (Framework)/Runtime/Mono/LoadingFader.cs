using System;
using System.Collections;
using UnityEngine;

public class LoadingFader : MonoBehaviour
{
    [SerializeField, Min(0)] private float _fadeInDuration = 0.5f;
    [SerializeField, Min(0)] private float _fadeOutDuration = 0.5f;
    [SerializeField, Min(0)] private float _minLoadingDuration = 0.5f;

    public event Action<float> OnFadeValueChanged;
    public event Action OnFadeInCompleted;
    public event Action OnFadeOutCompleted;

    private IEnumerator _fadeRoutine;

    public void FadeIn()
    {
        if (_fadeRoutine != null) return;

        _fadeRoutine = FadeRoutine(true);
        StartCoroutine(_fadeRoutine);
    }

    public void FadeOut()
    {
        if (_fadeRoutine != null) return;

        _fadeRoutine = FadeRoutine(false);
        StartCoroutine(_fadeRoutine);
    }


    private IEnumerator FadeRoutine(bool fadeIn)
    {
        float fadeProgress = 0f;

        while (fadeProgress < 1f)
        {
            fadeProgress = Mathf.Clamp01(fadeProgress + Time.unscaledDeltaTime / _fadeInDuration);
            OnFadeValueChanged?.Invoke(fadeIn ? fadeProgress : 1f - fadeProgress);
            yield return null;
        }

        if (fadeIn)OnFadeInCompleted?.Invoke();
        else OnFadeOutCompleted?.Invoke();
    }
}
