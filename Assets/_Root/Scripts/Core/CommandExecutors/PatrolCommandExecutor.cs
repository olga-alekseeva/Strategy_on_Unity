using System.Threading.Tasks;
using UnityEngine;
namespace Abstractions.Commands.CommandExecutors
{

    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        public override async Task ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"{name} is moving from " +
                $"{command.From} to {command.To}!");
        }
    }
}
