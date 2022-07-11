using System.Threading;

namespace Abstractions.Commands.CommandExecutors
{

    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        public CancellationTokenSource cancellationTokenSource { get; set; }
        public override void ExecuteSpecificCommand(IStopCommand command)
        {
            cancellationTokenSource?.Cancel();
        }
    }
}
