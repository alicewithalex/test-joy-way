
namespace NoName.Providers
{
    public abstract class AbstractStateDataProvider : UnityEngine.MonoBehaviour, Enums.IStateDataProvider
    {
        public abstract Data.StateData GetData(IContainer container);

        public abstract Enums.State State{ get; }
    }
}