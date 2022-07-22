using Abstractions.Commands;
using UnityEngine;
using Utils.AssetsInjector;
using Zenject;

public class ProduceUnitCommand : IProduceUnitCommand
{
    [Inject(Id = "SecondUnit")] public string UnitName { get; }
    [Inject(Id = "SecondUnit")] public Sprite Icon { get; }
    [Inject(Id = "SecondUnit")] public float ProductionTime { get; }
    public GameObject UnitPrefab => _unitPrefab;
    [InjectAsset("SecondUnit")] private GameObject _unitPrefab;
}
