using alicewithalex.Interfaces;

namespace alicewithalex.Data
{
    public class WetStatus : Status
    {
        public WetStatus(IDamagable target, float amount, float damage, int ticks = 3, float lifeTime = 2) : base(target, amount, damage, ticks, lifeTime)
        {
        }

        public override StatusType Type => StatusType.Wet;
        public override StatusType Negate => StatusType.OnFire;

        public override int Sign => -1;

        public override bool IsAffected(float value) => value < 0;

    }
}