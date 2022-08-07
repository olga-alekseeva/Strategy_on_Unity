using Abstractions;
using Abstractions.Commands.CommandInterfaces;

namespace Core
{

    public class HealCommand : IHealCommand
    {
        public IHealable Target { get; }

        public HealCommand(IHealable target)
        {
            Target = target;
        }
    }
}
