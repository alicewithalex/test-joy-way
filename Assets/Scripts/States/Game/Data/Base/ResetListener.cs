using UnityEngine;
using UnityEngine.Events;

namespace alicewithalex.Data
{
    public class ResetListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onReset;

        public void ResetObject() => _onReset?.Invoke();
    }
}