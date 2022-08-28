using Abstractions.Commands;
using UnityEngine;

public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
{
    public override void ExecuteSpecificCommand(IPatrolCommand command)
    {
        Debug.Log($"{name} is moving from " +
            $"{command.From} to {command.To}!");
    }
}
 