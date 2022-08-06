using Abstractions;
using Abstractions.Commands.CommandInterfaces;

namespace Core
{

    public class HealCommand : IHealCommand
    {
        public IAttackable Target { get; }

        public HealCommand(IAttackable target)
        {
            Target = target;
        }
    }
}
