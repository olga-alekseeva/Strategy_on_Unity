using Abstractions.Commands;
using System;
using Utils.AssetsInjector;
using Zenject;

namespace UI.Model.CommandCreators
{

    public class ProduceUnitCommandCommandCreator :
    CommandCreatorBase<IProduceUnitCommand>
    {
        [Inject] private AssetsContext _context;
        [Inject] private DiContainer _diContainer;

        protected override void
        classSpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
        {
            var produceUnitCommand = _context.Inject(new ProduceUnitCommandHeir());
            _diContainer.Inject(produceUnitCommand);
            creationCallback?.Invoke(produceUnitCommand);
        }

    }
}
