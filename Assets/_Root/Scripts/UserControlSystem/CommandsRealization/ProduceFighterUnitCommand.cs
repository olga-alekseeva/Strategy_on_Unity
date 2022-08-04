using Abstractions.Commands;
using UnityEngine;
using Utils.AssetsInjector;
using Zenject;
namespace UserControlSystem.CommandsRealization
{

    public class ProduceFighterUnitCommand : IProduceUnitCommand
    {
        [Inject(Id = "Fighter")] public string UnitName { get; }
        [Inject(Id = "Fighter")] public Sprite Icon { get; }
        [Inject(Id = "Fighter")] public float ProductionTime { get; }
        public GameObject UnitPrefab => _unitPrefab;
        [InjectAsset("Fighter")] private GameObject _unitPrefab;
    }
}
