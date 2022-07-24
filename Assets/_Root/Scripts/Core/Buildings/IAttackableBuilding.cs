namespace Abstractions
{
    internal interface IAttackableBuilding: IHealthValue
    {
        void ReceiveDamage(int amount);
    }
}