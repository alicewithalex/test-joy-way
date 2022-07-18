using alicewithalex.Data;
using DG.Tweening;
using NoName.Injection;
using NoName.Systems;

namespace alicewithalex.Systems
{
    public class PlayerDropSystem : IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _data;

        public void StateUpdate()
        {
            if (_data.Inventory is null) return;

            if (_data.Input.LeftHandReleased) Throw(_data.Inventory.Remove(HandType.Left));
            if (_data.Input.RightHandReleased) Throw(_data.Inventory.Remove(HandType.Right));
        }

        private void Throw(Pickup pickup)
        {
            if (pickup == null) return;

            pickup.Release();

            pickup.transform.DOKill();

            pickup.transform.position = _data.Player.transform.position + _data.Player.transform.forward;
            pickup.transform.DOMove(_data.Player.transform.position + _data.Player.transform.forward * 2f, 1f)
                .SetEase(Ease.OutQuad);
        }

    }
}