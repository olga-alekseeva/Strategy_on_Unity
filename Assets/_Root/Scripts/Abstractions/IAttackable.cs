namespace Abstractions
{
    public interface IAttackable : IHealthValue
    {
        void ReceiveDamage(int amount);
        void ReceiveHeal(int amount);
    }

}