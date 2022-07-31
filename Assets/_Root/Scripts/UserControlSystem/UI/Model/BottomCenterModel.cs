using System;
using Zenject;
using UniRx;
using UnityEngine;
using Abstractions.Commands;
using Abstractions;

public class BottomCenterModel 
{
    public IObservable<IFighterUnitProducer> UnitProducers { get; private set; }
    [Inject]
    public void Init(IObservable<ISelectable> currentlySelected)
    {
        UnitProducers = currentlySelected
            .Select(selectable => selectable as Component)
            .Select(component => component?.GetComponent<IFighterUnitProducer>());
    }
}
