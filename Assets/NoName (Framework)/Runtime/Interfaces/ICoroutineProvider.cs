using System.Collections;

public interface ICoroutineProvider 
{
    void Run(IEnumerator coroutine);

    void Stop(IEnumerator coroutine);
}
