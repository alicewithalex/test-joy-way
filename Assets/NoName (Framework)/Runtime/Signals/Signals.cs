
namespace NoName.Signals
{
    public static class Signals
    {
        private static readonly SignalsHub _signalsHub = new SignalsHub();

        public static T Get<T>() where T : ISignal, new()
        {
            return _signalsHub.Get<T>();
        }
    }
}