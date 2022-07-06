using System;
using Zenject;

namespace UI.Model.CommandCreators
{
    internal class PatrolCommandCommandCreator :
        CommandCreatorBase<IPatrolCommand>
    {
        [Inject] private AssetsContext _context;
        protected override void
        classSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new
            PatrolCommand()));
        }
    }
}
