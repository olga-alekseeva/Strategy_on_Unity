using Abstractions;
using Abstractions.Commands.CommandInterfaces;
using Core;

namespace UserControlSystem
{
    public class HealCommandCommandCreator :
       CancellableCommandCreatorBase<IHealCommand, IHealable>

    {
        protected override IHealCommand CreateCommand(IHealable argument) => new HealCommand(argument);
    }
}
