using UnityEngine;

namespace Abstractions.Commands
{
    public interface IProduceHealUnitCommand : ICommand, IIconHolder
    {
        GameObject UnitPrefab { get; }
        float ProductionTime { get; }
        string UnitName { get; }
    }
}
