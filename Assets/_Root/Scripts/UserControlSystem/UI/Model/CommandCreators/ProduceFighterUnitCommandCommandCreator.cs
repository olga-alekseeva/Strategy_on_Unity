using Abstractions.Commands;
using System;
using UserControlSystem.CommandsRealization;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem
{

    public class ProduceFighterUnitCommandCommandCreator :
    CommandCreatorBase<IProduceFighterUnitCommand>
    {
        [Inject] private AssetsContext _context;
        [Inject] private DiContainer _diContainer;

        protected override void
        ClassSpecificCommandCreation(Action<IProduceFighterUnitCommand> creationCallback)
        {
            var produceUnitCommand = _context.Inject(new ProduceUnitCommandHeir());
            _diContainer.Inject(produceUnitCommand);
            creationCallback?.Invoke(produceUnitCommand);
        }

    }
}
