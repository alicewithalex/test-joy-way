

using NoName.Data;

public abstract class ViewComponent<Data> : AbstractViewComponent where Data : StateData
{
    public override void Process(StateData stateData) => Process(stateData as Data);

    protected abstract void Process(Data stateData);

}
