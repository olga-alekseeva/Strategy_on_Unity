using Abstractions.Commands;
using Core;
using System;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem
{
    internal class StopCommandCommandCreator :
        CommandCreatorBase<IStopCommand>
    {
        [Inject] private AssetsContext _context;
        protected override void
        ClassSpecificCommandCreation(Action<IStopCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new StopCommand()));
        }
    }
}
