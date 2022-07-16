using System;

public interface ILoadingEventProvider
{
    event Action<bool> OnLoadingStateChanged;
    event Action<float> OnFadeValueChanged;
    event Action<float> OnLoadingProgressChanged;
}
