using Abstractions;
using Abstractions.Commands.CommandExecutors;
using UnityEngine;

namespace Core
{

public class MainUnit : MonoBehaviour, ISelectable, IAttackable
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Material _material;
    [SerializeField] private Transform _pivotPoint;
    [SerializeField] private StopCommandExecutor _stopCommand;
        private int _health = 100;
    public Sprite Icon => _icon;

    public Material Material => _material;

    public Transform PivotPoint => _pivotPoint;

    int IHealthValue.Health => _health;

    int IHealthValue.MaxHealth => _maxHealth;
}

}