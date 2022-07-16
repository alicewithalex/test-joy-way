using System;

public interface ITimer<T>
{
    bool Running { get; }

    void Cancel();

    void StartTimer(float duration, T value, Action<T> callback);
}
