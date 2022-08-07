namespace Abstractions.Commands.CommandInterfaces
{
    public interface IHealCommand : ICommand
    {
        public IHealable Target { get; }

    }
}
