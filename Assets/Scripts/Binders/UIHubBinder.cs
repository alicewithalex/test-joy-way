using NoName.UI;
using UnityEngine;

namespace alicewithalex.Binders
{
    public class UIHubBinder : Binder
    {
        [SerializeField] private UIHub _uiHub;

        public override void Bind(IContainer container)
        {
            _uiHub.Initialize();
            container.Bind<UIHub>(_uiHub);
        }
    }
}