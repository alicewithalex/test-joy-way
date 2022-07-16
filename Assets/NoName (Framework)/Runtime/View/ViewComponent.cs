

public abstract class ViewComponent<T> : AbstractViewComponent where T : StateData
{
    public override void Process(StateData stateData) => Process(stateData as T);

    protected abstract void Process(T stateData);

}
