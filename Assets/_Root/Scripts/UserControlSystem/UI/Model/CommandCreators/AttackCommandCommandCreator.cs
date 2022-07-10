using Abstractions;
using Abstractions.Commands.CommandInterfaces;
using System;
using System.Threading;
using UserControlSystem.UI.Model;
using Utils;
using Utils.AssetsInjector;
using Zenject;

namespace UI.Model.CommandCreators
{
    public class AttackCommandCommandCreator :
       CancellableCommandCreatorBase<IAttackCommand, IAttackable>

    {
        protected override IAttackCommand createCommand(IAttackable argument) => new
AttackCommand(argument);
    }
}
