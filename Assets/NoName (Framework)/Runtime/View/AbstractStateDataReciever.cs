
namespace NoName.Data
{
    public abstract class AbstractStateDataReciever : UnityEngine.MonoBehaviour
    {
        public abstract void Receive(StateData stateData);

        public abstract System.Type Type { get; }
    }
}