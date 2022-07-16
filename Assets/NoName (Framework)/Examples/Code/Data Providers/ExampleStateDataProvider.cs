using UnityEngine;
using UnityEngine.UI;

public class ExampleStateDataProvider : StateDataProvider
{
    [SerializeField] private Transform _player;
    [SerializeField] private KeyCode _nextStateKey;

    public override StateData GetData()
    {
        ExampleStateData data = new ExampleStateData();

        data.Player = _player;
        data.NextStateKey = _nextStateKey;

        return data;
    }
}
