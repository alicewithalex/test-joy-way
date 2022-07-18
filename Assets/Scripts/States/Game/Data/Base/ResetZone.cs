using UnityEngine;

namespace alicewithalex.Data
{
    public class ResetZone : MonoBehaviour
    {
        [SerializeField] private string _interactionTag;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(_interactionTag)) return;

            if (other.TryGetComponent<ResetListener>(out var listener))
            {
                listener.ResetObject();
            }
            else
            {
                if ((listener = other.GetComponentInParent<ResetListener>()) != null)
                {
                    listener.ResetObject();
                }
            }
        }
    }
}