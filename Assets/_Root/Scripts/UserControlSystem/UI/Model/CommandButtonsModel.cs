using System;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandInterfaces;
using UnityEngine;
using Zenject;

namespace UserControlSystem
{
    public sealed class CommandButtonsModel
    {
        public event Action<ICommandExecutor> OnCommandAccepted;
        public event Action OnCommandSent;
        public event Action OnCommandCancel;

        [Inject] private CommandCreatorBase<IProduceFighterUnitCommand> _fighterUnitProducer;
        [Inject] private CommandCreatorBase<IProduceHealerUnitCommand> _healerUnitProducer;
        [Inject] private CommandCreatorBase<IAttackCommand> _attacker;
        [Inject] private CommandCreatorBase<IStopCommand> _stopper;
        [Inject] private CommandCreatorBase<IMoveCommand> _mover;
        [Inject] private CommandCreatorBase<IPatrolCommand> _patroller;
        [Inject] private CommandCreatorBase<ISetRallyPointCommand> _setRally;
        [Inject] private CommandCreatorBase<IProduceResourcesCommand> _produceResources;

        private bool _commandIsPending;

        public void OnCommandButtonClicked(ICommandExecutor commandExecutor, ICommandsQueue commandsQueue)
        {
            if (_commandIsPending)
            {
                processOnCancel();
            }
            _commandIsPending = true;
            OnCommandAccepted?.Invoke(commandExecutor);

            _fighterUnitProducer.ProcessCommandExecutor(commandExecutor, command => ExecuteCommandWrapper(command, commandsQueue));
            _healerUnitProducer.ProcessCommandExecutor(commandExecutor, command => ExecuteCommandWrapper(command, commandsQueue));
            _attacker.ProcessCommandExecutor(commandExecutor, command => ExecuteCommandWrapper(command, commandsQueue));
            _stopper.ProcessCommandExecutor(commandExecutor, command => ExecuteCommandWrapper(command, commandsQueue));
            _mover.ProcessCommandExecutor(commandExecutor, command => ExecuteCommandWrapper(command, commandsQueue));
            _patroller.ProcessCommandExecutor(commandExecutor, command => ExecuteCommandWrapper(command, commandsQueue));
            _setRally.ProcessCommandExecutor(commandExecutor, command => ExecuteCommandWrapper(command, commandsQueue));
            _produceResources.ProcessCommandExecutor(commandExecutor, command => ExecuteCommandWrapper(command, commandsQueue));
        }

        public void ExecuteCommandWrapper(object command, ICommandsQueue commandsQueue)
        {
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftShift))
            {
                commandsQueue.Clear();
            }
            commandsQueue.EnqueueCommand(command);
            _commandIsPending = false;
            OnCommandSent?.Invoke();
        }

        public void OnSelectionChanged()
        {
            _commandIsPending = false;
            processOnCancel();
        }

        private void processOnCancel()
        {
            _fighterUnitProducer.ProcessCancel();
            _healerUnitProducer.ProcessCancel();
            _attacker.ProcessCancel();
            _stopper.ProcessCancel();
            _mover.ProcessCancel();
            _patroller.ProcessCancel();
            _setRally.ProcessCancel();
            _produceResources.ProcessCancel();

            OnCommandCancel?.Invoke();
        }
    }
}