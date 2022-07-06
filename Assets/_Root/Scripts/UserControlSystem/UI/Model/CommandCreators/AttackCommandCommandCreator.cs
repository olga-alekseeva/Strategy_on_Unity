using System;
using Zenject;

namespace UI.Model.CommandCreators
{
    public class AttackCommandCommandCreator :
        CommandCreatorBase<IAttackCommand>

    {
        private IAttackable _target;
        [Inject] private AssetsContext _context;
        protected override void
        classSpecificCommandCreation(Action<IAttackCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new
            AttackCommand(_target)));
        }
    }
}
