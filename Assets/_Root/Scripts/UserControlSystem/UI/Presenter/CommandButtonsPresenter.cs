using Abstractions;
using Abstractions.Commands;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;
    [SerializeField] private AssetsContext _context;

    private ISelectable _currentSelectable;
    private void Start()
    {
        _selectable.OnSelected += onSelected;
        onSelected(_selectable.CurrentValue);
        _view.OnClick += onButtonClick;
    }
    private void onSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        _currentSelectable = selectable;
        _view.Clear();
        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as
            Component).GetComponentsInParent<ICommandExecutor>());
            _view.MakeLayout(commandExecutors);
        }
    }
    private void onButtonClick(ICommandExecutor commandExecutor)
    {
        var unitProducer = commandExecutor as
    CommandExecutorBase<IProduceUnitCommand>;
        if (unitProducer != null)
        {
           unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
            return;
        }
        var moveCommand = commandExecutor as
    CommandExecutorBase<IMoveCommand>;
        if(moveCommand != null)
        {
            moveCommand.ExecuteSpecificCommand(_context.Inject(new MoveCommand()));
            return;
        }
        var attackCommand = commandExecutor as 
            CommandExecutorBase<IAttackCommand>;
        if (attackCommand != null)
        {
            attackCommand.ExecuteSpecificCommand(_context.Inject(new AttackCommand()));
            return;
        }
        var patrolComand = commandExecutor as
            CommandExecutorBase<IPatrolCommand>;
        if (patrolComand != null)
        {
            patrolComand.ExecuteSpecificCommand(_context.Inject(new PatrolCommand()));
            return;
        }
        var stopCommand = commandExecutor as
            CommandExecutorBase<IStopCommand>;
        if (stopCommand != null)
        {

            stopCommand.ExecuteSpecificCommand(_context.Inject(new StopCommand()));
            return;
        }

            throw new
        ApplicationException($"{nameof(CommandButtonsPresenter)}" +
        $".{nameof(onButtonClick)}:Unknown type of commands executor: { commandExecutor.GetType().FullName }!");
            
    }
}
