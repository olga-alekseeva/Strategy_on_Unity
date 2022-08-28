using Abstractions.Commands;
using UnityEngine;
using Utils.AssetsInjector;

public class ProduceUnitCommand : IProduceUnitCommand
{
    public GameObject UnitPrefab => _unitPrefab;
    [InjectAsset("Hare")] private GameObject _unitPrefab;
}
