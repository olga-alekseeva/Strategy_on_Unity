using UnityEngine;

namespace Abstractions
{
    public interface IHealable : IHealthValue
    {
        void Heal(int amount);
        Transform Transform { get; }
    }
}
