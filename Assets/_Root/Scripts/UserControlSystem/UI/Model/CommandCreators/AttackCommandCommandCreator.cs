using Abstractions;
using Abstractions.Commands.CommandInterfaces;
using Core;

namespace UserControlSystem
{
    public class AttackCommandCommandCreator :
       CancellableCommandCreatorBase<IAttackCommand, IAttackable>

    {
        protected override IAttackCommand CreateCommand(IAttackable argument) => new AttackCommand(argument);
    }
}
