using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandExecutors;
using Core;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UserControlSystem.UI.Model;
using Zenject;

namespace UserControlSystem
{

    public class RMBMoveExecutor : MonoBehaviour
    {
        [Inject] private RMBMoveData _moveData;
        [Inject] private CommandCreatorBase<IMoveCommand> _commandCreator;
        private MoveCommandExecutor _moveCommandExecutor;
        private ISelectable _selectedUnit;
        private ICommandsQueue _unitCommandsQueue;
        private bool _commandIsPending = false;

        private void Awake()
        {
            _moveCommandExecutor = gameObject.GetComponent<MoveCommandExecutor>();
            _selectedUnit = gameObject.GetComponent<ISelectable>();
            _unitCommandsQueue = gameObject.GetComponent<ICommandsQueue>();
            MessageBroker.Default.Receive<CommandPending>().Subscribe(CommandPending_Changed);
        }
        private void CommandPending_Changed(CommandPending commandPending)
        {
            _commandIsPending = commandPending.value;
        }
        private void Start()
        {
            _moveData.vector3Value.OnNewValue += RMB_Pressed;
        }
        private void RMB_Pressed(Vector3 vector3)
        {
            if (_commandIsPending)
                return;
            if (_moveData.selectableValue.CurrentValue != _selectedUnit)
                return;
            _unitCommandsQueue.EnqueueCommand(new MoveCommand(vector3));

        }
    }
}
