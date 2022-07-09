using Abstractions;
using Abstractions.Commands;

namespace Abstractions.Commands.CommandInterfaces
{
    public interface IAttackCommand : ICommand
    {
        public IAttackable Target { get; }

    }
}
