namespace Abstractions.Commands.CommandInterfaces
{
    public interface IAttackCommand : ICommand
    {
        public IAttackable Target { get; }

    }
}
