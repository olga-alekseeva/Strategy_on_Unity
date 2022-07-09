using Abstractions.Commands;
using System;
using Utils.AssetsInjector;
using Zenject;

namespace UI.Model.CommandCreators
{
    internal class StopCommandCommandCreator :
        CommandCreatorBase<IStopCommand>
    {
        [Inject] private AssetsContext _context;
        protected override void
        classSpecificCommandCreation(Action<IStopCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new
            StopCommand()));
        }
    }
}
