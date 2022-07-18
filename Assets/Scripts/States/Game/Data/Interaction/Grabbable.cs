
namespace alicewithalex.Data
{
    public class Grabbable : Pickup
    {
        protected bool _grabbed;

        public override bool Interactable => !_grabbed;

        public override void Interact()
        {
            if (!Interactable) return;

            _grabbed = true;
        }

        public override void Release() => _grabbed = false;
    }
}