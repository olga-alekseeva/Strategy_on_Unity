using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserControlSystem;
using Abstractions.Commands;
using System;
using Zenject;
using Utils.AssetsInjector;
using Abstractions;
using Core;

internal class ProduceResourcesCommandCommandCreator : CommandCreatorBase<IProduceResourcesCommand>
{
    [Inject] private AssetsContext _context;

    protected override void ClassSpecificCommandCreation(Action<IProduceResourcesCommand> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new ProduceResourcesCommand()));
    }
}
