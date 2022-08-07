using Abstractions;
using System;
using UnityEngine;
using UnityEngine.UI;
using UserControlSystem;
using UserControlSystem.UI.Model;
using Utils;
using Utils.AssetsInjector;
using Zenject;

[CreateAssetMenu(fileName = "AssetsInstaller", menuName = "Installers/AssetsInstaller")]
public class AssetsInstaller : ScriptableObjectInstaller<AssetsInstaller>
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackableClicksRMB;
    [SerializeField] private SelectableValue _selectables;
    [SerializeField] private HealableValue _healableValue;
    private RMBMoveData _rMBMoveData;
    public override void InstallBindings()
    {
        Container.Bind<IAwaitable<IAttackable>>()
            .FromInstance(_attackableClicksRMB);
        Container.Bind<IAwaitable<Vector3>>()
            .FromInstance(_groundClicksRMB);
        Container.Bind<IAwaitable<IHealable>>()
            .FromInstance(_healableValue);
        Container.Bind<IObservable<ISelectable>>()
            .FromInstance(_selectables);
        Container.BindInstances(_legacyContext, _selectables);
        _rMBMoveData = new RMBMoveData();
        _rMBMoveData.selectableValue = _selectables;
        _rMBMoveData.vector3Value = _groundClicksRMB;
        Container.Bind<RMBMoveData>().FromInstance(_rMBMoveData);
    }

}