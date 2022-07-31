using UnityEngine;

namespace Abstractions.Commands
{
    public interface IProduceFighterUnitCommand : ICommand, IIconHolder
    {
        GameObject UnitPrefab { get; }
        float ProductionTime { get; }
        string UnitName { get; }
    }
}
