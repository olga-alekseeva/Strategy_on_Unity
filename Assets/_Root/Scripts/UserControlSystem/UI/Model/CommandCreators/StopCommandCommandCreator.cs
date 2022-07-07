using System;
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
