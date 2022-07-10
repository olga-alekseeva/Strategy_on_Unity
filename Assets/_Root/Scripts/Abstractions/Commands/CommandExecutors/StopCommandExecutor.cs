using Abstractions.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstractions.Commands.CommandExecutors
{

public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
{
    public override void ExecuteSpecificCommand(IStopCommand command)
    {
        Debug.Log("Stop");
    }
}
}
