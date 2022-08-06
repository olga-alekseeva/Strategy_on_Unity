namespace Abstractions.Commands.CommandInterfaces
{
    public interface IHealCommand : ICommand
    {
        public IAttackable Target { get; }

    }
}
