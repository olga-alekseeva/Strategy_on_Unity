using Abstractions;
using Abstractions.Commands.CommandInterfaces;
using Abstractions.Commands;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class HealerCommandsQueue : MonoBehaviour, ICommandsQueue
{
    [Inject] CommandExecutorBase<IMoveCommand> _moveCommandExecutor;
    //[Inject] CommandExecutorBase<IStopCommand> _stopCommandExecutor;

    private ReactiveCollection<ICommand> _innerCollection = new ReactiveCollection<ICommand>();
    public ICommand CurrentCommand => _innerCollection.Count > 0 ? _innerCollection[0] : default;

    [Inject]

    private void Init()
    {
        _innerCollection.ObserveAdd().Subscribe(OnNewCommand).AddTo(this);
    }

    private void OnNewCommand(ICommand command, int index)
    {
        if (index == 0)
        {
            ExecuteCommand(command);
        }
    }
    private async void ExecuteCommand(ICommand command)
    {
        await _moveCommandExecutor.TryExecuteCommand(command);
       // await _stopCommandExecutor.TryExecuteCommand(command);
        if (_innerCollection.Count > 0)
        {
            _innerCollection.RemoveAt(0);
        }
        checkTheQueue();
    }
    private void checkTheQueue()
    {
        if (_innerCollection.Count > 0)
        {
            ExecuteCommand(_innerCollection[0]);
        }
    }
    public void EnqueueCommand(object wrappedCommand)
    {
        var command = wrappedCommand as ICommand;
        _innerCollection.Add(command);
    }
    public void Clear()
    {
        _innerCollection.Clear();
    }
}
