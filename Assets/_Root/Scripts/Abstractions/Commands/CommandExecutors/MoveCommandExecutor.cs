using Abstractions.Commands;
using UnityEngine;

public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
{
    public override void ExecuteSpecificCommand(IMoveCommand command)
    {
        Debug.Log($"{name} is moving to {command.Target}!");
    }
}