using alicewithalex.Data;
using UnityEngine;

namespace alicewithalex.Providers
{
    public class LoadingStateDataProvider : StateDataProvider
    {
        [SerializeField] private Material _overlayMaterial;

        public override StateData GetData()
        {
            LoadingStateData loadingStateData = new LoadingStateData();

            loadingStateData.OverlayMaterial = _overlayMaterial;

            return loadingStateData;
        }
    }
}