using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;

namespace alicewithalex.Systems
{
    public class InventorySystem : IInitializeSystem
    {
        [Inject] private readonly GameStateData _data;

        public void OnInitialize()
        {
            _data.Inventory = new Inventory(_data.Hands);
        }
    }
}