using Abstractions;
using Abstractions.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core
{

public class HospitalBuildingCommandQueue : MonoBehaviour, ICommandsQueue
{
        public ICommand CurrentCommand => default;

        [Inject] CommandExecutorBase<IProduceHealUnitCommand> _produceHealllUnitCommandExecutor;
       // [Inject] CommandExecutorBase<ISetRallyPointCommand> _setRallyCommandExecutor;

        public void Clear() { }

        public async void EnqueueCommand(object command)
        {
            await _produceHealllUnitCommandExecutor.TryExecuteCommand(command);
           // await _setRallyCommandExecutor.TryExecuteCommand(command);
        }
    }
}

