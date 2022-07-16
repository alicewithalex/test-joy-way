using NoName.Injection;
using NoName.StateMachine;
using System.Collections.Generic;

public abstract class StateData
{
    protected StateData()
    {
        Saveables = new Dictionary<string, ISaveable>();
    }

    public abstract State State { get; }

    [Inject]
    public readonly ISavingPromoter SavingPromoter;

    public Dictionary<string, ISaveable> Saveables { get; private set; }

    public void AddSaveable(ISaveable saveable)
    {
        if (Saveables.ContainsKey(saveable.Identificator)) return;
        Saveables.Add(saveable.Identificator, saveable);
    }
}
