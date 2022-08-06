using Abstractions;
using Abstractions.Commands.CommandInterfaces;
using Core;

namespace UserControlSystem
{
    public class HealCommandCommandCreator :
       CancellableCommandCreatorBase<IHealCommand, IAttackable>

    {
        protected override IHealCommand CreateCommand(IAttackable argument) => new HealCommand(argument);
    }
}
