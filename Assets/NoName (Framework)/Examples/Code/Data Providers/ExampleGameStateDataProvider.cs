using UnityEngine;

public class ExampleGameStateDataProvider : StateDataProvider
{
    [SerializeField] private KeyCode _nextStateKey;

    public override StateData GetData()
    {
        ExampleGameStateData data = new ExampleGameStateData();

        data.NextStateKey = _nextStateKey;

        return data;
    }

   
}
