using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;

namespace alicewithalex.Systems
{
    public class InventorySystem : IInitializeSystem
    {
        [Inject] private readonly GameStateData _stateData;

        public void OnInitialize()
        {
            _stateData.Inventory = new Inventory(_stateData.Hands);
        }
    }
}