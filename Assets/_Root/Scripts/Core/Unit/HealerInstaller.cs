using Abstractions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HealerInstaller : MonoInstaller

{
    [SerializeField] private AttackerParallelnfoUpdater _attackerParallelnfoUpdater;
    [SerializeField] private FactionMemberParallelInfoUpdater _factionMemberParallelInfoUpdater;

    public override void InstallBindings()
    {
        Container.Bind<IHealthValue>().FromComponentInChildren();
        Container.Bind<float>().WithId("AttackDistance").FromInstance(5f);
        Container.Bind<int>().WithId("AttackPeriod").FromInstance(1400);

        Container.Bind<IAutomaticAttacker>().FromComponentInChildren();
        Container.Bind<ITickable>().FromInstance(_attackerParallelnfoUpdater);
        Container.Bind<ITickable>().FromInstance(_factionMemberParallelInfoUpdater);
        Container.Bind<IFactionMember>().FromComponentInChildren();
        Container.Bind<ICommandsQueue>().FromComponentInChildren();
    }
}
