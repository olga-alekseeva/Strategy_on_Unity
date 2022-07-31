using Abstractions.Commands;
using UnityEngine;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem.CommandsRealization
{
    public class ProduceHealerUnitCommand
    {
        public class ProduceFighterUnitCommand : IProduceFighterUnitCommand
        {
            [Inject(Id = "Healer")] public string UnitName { get; }
            [Inject(Id = "Healer")] public Sprite Icon { get; }
            [Inject(Id = "Healer")] public float ProductionTime { get; }
            public GameObject UnitPrefab => _unitPrefab;
            [InjectAsset("Healer")] private GameObject _unitPrefab;
        }
    }
}
