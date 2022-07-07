﻿using System;
using Zenject;

namespace UI.Model.CommandCreators
{
    public class AttackCommandCommandCreator :
        CommandCreatorBase<IAttackCommand>

    {
        [Inject] private AssetsContext _context;
        private Action<IAttackCommand> _creationCallback;
        [Inject]
        private void Init(AttackableValue groundClicks)
        {
            groundClicks.OnNewValue += onNewValue;
        }
        private void onNewValue(IAttackable attackable)
        {
            _creationCallback?.Invoke(_context.Inject(new AttackCommand(attackable)));
            _creationCallback = null;
        }
        protected override void classSpecificCommandCreation(Action<IAttackCommand>
        creationCallback)
        {
            _creationCallback = creationCallback;
        }
        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _creationCallback = null;
        }
    }
}
