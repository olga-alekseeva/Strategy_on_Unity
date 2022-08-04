using Abstractions;
using Abstractions.Commands;
using UnityEngine;
using Zenject;

namespace Core
{
    public class BuildingsCommandQueue : MonoBehaviour, ICommandsQueue
    {
        [Inject] CommandExecutorBase<IProduceUnitCommand> _produceUnitCommandExecutor;
        [Inject] CommandExecutorBase<ISetRallyPointCommand> _setRallyCommandExecutor;
        public ICommand CurrentCommand => default;
        public void Clear() { }

        public async void EnqueueCommand(object command)
        {
            await _produceUnitCommandExecutor.TryExecuteCommand(command);
            await _setRallyCommandExecutor.TryExecuteCommand(command);
        }

    }

}