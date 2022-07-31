using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Abstractions.Commands
{

public interface IProduceHealerUnitCommand : ICommand, IIconHolder
{
        GameObject UnitPrefab { get; }
        float ProductionTime { get; }
        string UnitName { get; }
    }
}
