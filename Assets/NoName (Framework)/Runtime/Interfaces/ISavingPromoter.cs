using System;

public interface ISavingPromoter
{
    public void Save(int slot);

    public void Load(int slot);

    public void LoadLastSave();

    public bool IsSlotEmpty(int slot);

    public event Action<int> OnSaved;
}
