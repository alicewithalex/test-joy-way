namespace alicewithalex.Data
{
    public class Damage
    {
        public readonly float Amount;
        public readonly Status Status;

        public Damage(float amount, Status status)
        {
            Amount = amount;
            Status = status;
        }
    }
}