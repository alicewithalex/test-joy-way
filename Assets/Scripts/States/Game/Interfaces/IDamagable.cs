using alicewithalex.Data;

namespace alicewithalex.Interfaces
{
    public interface IDamagable
    {
        void Damage(float amount, bool modifiable = false);

        bool Refresh(Status status);
    }
}