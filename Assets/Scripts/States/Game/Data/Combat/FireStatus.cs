using alicewithalex.Interfaces;
using System.Collections.Generic;

namespace alicewithalex.Data
{
    public class FireStatus : Status
    {
        public FireStatus(IDamagable target, List<DamageModifier> damageModifiers,
            float amount, float damage, int ticks = 3, float lifeTime = 2) : base(target, damageModifiers, amount, damage, ticks, lifeTime)
        {
        }

        public override StatusType Type => StatusType.OnFire;

        public override StatusType Negate => StatusType.Wet;

        public override int Sign => 1;

        public override bool IsAffected(float value) => value > 0;
    }
}