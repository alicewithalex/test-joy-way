using alicewithalex.Data;

namespace alicewithalex.Providers
{
    public class StartStateDataProvider : StateDataProvider
    {
        public override StateData GetData()
        {
            StartStateData startStateData = new StartStateData();


            return startStateData;
        }
    }
}