using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NoName.Debugging;
using NoName.EditorExtended;
using NoName.StateMachine;
using UnityEngine;

namespace NoName.UI
{
    public class UIHub : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _fadeTime;
        [SerializeField] private State _previewScreen;
        [SerializeField] private List<UIScreen> _screens = new List<UIScreen>();

        private Dictionary<State, UIScreen> _screenStateMap = new Dictionary<State, UIScreen>();

        public void Initialize()
        {
            foreach (var screen in _screens)
            {
                if (!_screenStateMap.ContainsKey(screen.State))
                {
                    _screenStateMap.Add(screen.State, screen);
                }
                else
                {
                    throw new ArgumentException($"{screen.ToString().Colorize(DColor.Orange, true)}" +
                        $" is already in UI Hub!");
                }
            }
            _screens.Clear();

            ToggleAll(false);
        }

        private void ToggleAll(bool on)
        {
            foreach (var screen in _screenStateMap.Values)
            {
                if (on) screen.Show();
                else screen.Hide();
            }
        }

        public T GetScreen<T>(State state) where T : UIScreen
        {
            if (!_screenStateMap.ContainsKey(state)) throw new KeyNotFoundException(
                 $"There are no UI Screen for {state.ToString().Colorize(DColor.Mint, true)}state");

            return _screenStateMap[state] as T;
        }

        public void Show(State state)
        {
            if (_screenStateMap.ContainsKey(state)) _screenStateMap[state].Show();
        }

        public void Hide(State state)
        {
            if (_screenStateMap.ContainsKey(state)) _screenStateMap[state].Hide();
        }

        public void Fade(bool fadeIn, Action<float> onValueChanged, Action onComplete)
        {
            if (_fadeTime <= 0)
            {
                onValueChanged?.Invoke(1f);
                onComplete?.Invoke();
                return;
            }

            StartCoroutine(FadeRoutine(fadeIn, onValueChanged, onComplete));
        }

        private IEnumerator FadeRoutine(bool fadeIn, Action<float> onValueChanged, Action onComplete)
        {
            float t = 0;
            while (t < 1f)
            {
                t = Mathf.Clamp01(t + Time.deltaTime / _fadeTime);
                onValueChanged?.Invoke(fadeIn ? t : 1 - t);
                yield return null;
            }
            onValueChanged?.Invoke(fadeIn ? 1 : 0);
            onComplete?.Invoke();
        }

        #region Editor

#if UNITY_EDITOR

        [Button("Collect")]
        public void Collect()
        {
            _screens = GetComponentsInChildren<UIScreen>().ToList();

#if UNITY_EDITOR

            UnityEditor.EditorUtility.SetDirty(this);

#endif

        }

        [Button("Show Preview")]
        public void ShowPreview()
        {
            foreach (var screen in _screens)
            {
                if (!screen.State.Equals(_previewScreen)) screen.Hide();
                else screen.Show();
            }

#if UNITY_EDITOR

            UnityEditor.EditorUtility.SetDirty(this);

#endif
        }

        [Button("Hide All")]
        public void HideAll()
        {
            foreach (var screen in _screens)
            {
                screen.Hide();
            }

#if UNITY_EDITOR

            UnityEditor.EditorUtility.SetDirty(this);

#endif

        }
#endif
        #endregion
    }
}