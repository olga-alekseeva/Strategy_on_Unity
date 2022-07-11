using Abstractions;
using Abstractions.Commands.CommandInterfaces;

namespace UI.Model.CommandCreators
{
    public class AttackCommandCommandCreator :
       CancellableCommandCreatorBase<IAttackCommand, IAttackable>

    {
        protected override IAttackCommand createCommand(IAttackable argument) => new
AttackCommand(argument);
    }
}
