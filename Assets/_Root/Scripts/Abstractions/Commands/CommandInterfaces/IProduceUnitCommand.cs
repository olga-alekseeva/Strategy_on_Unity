using UnityEngine;

namespace Abstractions.Commands
{
    public interface IProduceUnitCommand : ICommand
    {
        GameObject UnitPrefab { get; }
        float ProductionTime { get; }
        Sprite Icon { get; }
        string UnitName { get; }
    }
}
