using Abstractions.Commands;

namespace Abstractions
{
    public interface ICommandsQueue
    {
        void EnqueueCommand(object command);
        void Clear();
        ICommand CurrentCommand { get; }
    }
}