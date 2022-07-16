public interface ISaveable
{
    public string Identificator { get; }

    public void OnLoad(string value);

    public string OnSave();

}
