using Abstractions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HospitalBuildingInstaller : MonoInstaller
{
    [SerializeField] private FactionMemberParallelInfoUpdater _factionMemberParallelInfoUpdater;

    public override void InstallBindings()
    {
        Container
            .Bind<ITickable>()
            .FromInstance(_factionMemberParallelInfoUpdater);
        Container.Bind<IFactionMember>().FromComponentInChildren();
    }
}

