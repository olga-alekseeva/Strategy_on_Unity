using Abstractions;
using Abstractions.Commands;
using UnityEngine;

namespace Core
{

    public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable, IAttackable
    {
        [SerializeField] private int _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Material _material;
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private Transform _pivotPoint;
        private int _health = 1000;
        public Sprite Icon => _icon;
        public Material Material => _material;

        public Transform PivotPoint => _pivotPoint;

        int IHealthValue.Health => _health;

        int IHealthValue.MaxHealth => _maxHealth;

        public override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(command.UnitPrefab, new Vector3(Random.Range
                (-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        }

    }
}

