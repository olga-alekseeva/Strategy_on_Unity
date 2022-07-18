using System.Threading;
using System.Threading.Tasks;

namespace Abstractions.Commands.CommandExecutors
{

    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        public CancellationTokenSource cancellationTokenSource { get; set; }
        public override async Task ExecuteSpecificCommand(IStopCommand command)
        {
            cancellationTokenSource?.Cancel();
        }
    }
}
