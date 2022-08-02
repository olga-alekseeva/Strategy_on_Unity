using Abstractions.Commands;
using System;
using UserControlSystem.CommandsRealization;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem
{

    public class ProduceHealerUnitCommandCommandCreator :
    CommandCreatorBase<IProduceHealerUnitCommand>
    {
        [Inject] private AssetsContext _context;
        [Inject] private DiContainer _diContainer;

        protected override void
        ClassSpecificCommandCreation(Action<IProduceHealerUnitCommand> creationCallback)
        {
            var produceUnitCommand = _context.Inject(new ProduceHealerCommandHeir());
            _diContainer.Inject(produceUnitCommand);
            creationCallback?.Invoke(produceUnitCommand);
        }

    }
}
