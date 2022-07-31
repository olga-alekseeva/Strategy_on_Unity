using Abstractions;
using Abstractions.Commands;
using UnityEngine;
using Zenject;
public class FarmCommandsQueue : MonoBehaviour, ICommandsQueue
{
    [Inject] CommandExecutorBase<IProduceResourcesCommand> _produceResourcesCommandExecutor;

    public ICommand CurrentCommand => default;

    public void Clear()
    {  }

    public async void EnqueueCommand(object command)
    {
        await _produceResourcesCommandExecutor.TryExecuteCommand(command);
    }
}
