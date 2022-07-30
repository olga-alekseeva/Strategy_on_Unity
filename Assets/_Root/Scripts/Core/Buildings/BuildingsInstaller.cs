using Abstractions;
using UnityEngine;
using Zenject;

public class BuildingsInstaller : MonoInstaller
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
