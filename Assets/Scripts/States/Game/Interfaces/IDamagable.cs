using alicewithalex.Data;

namespace alicewithalex.Interfaces
{
    public interface IDamagable
    {
        void Damage(float amount);

        bool Refresh(Status status);
    }
}