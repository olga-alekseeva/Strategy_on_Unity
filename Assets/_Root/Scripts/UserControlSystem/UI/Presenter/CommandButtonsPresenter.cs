using Abstractions;
using Abstractions.Commands;
using System;
using System.Collections.Generic;
using UI.View;
using UniRx;
using UnityEngine;
using Zenject;

namespace UserControlSystem
{

public sealed class CommandButtonsPresenter : MonoBehaviour
{
   
    [SerializeField] private CommandButtonsView _view;
    [Inject] private IObservable<ISelectable> _selectedValues;
    [Inject] private CommandButtonsModel _model;

    private ISelectable _currentSelectable;
    private void Start()
    {
        _view.OnClick += _model.OnCommandButtonClicked;
        _model.OnCommandSent += _view.UnblockAllInteractions;
        _model.OnCommandCancel += _view.UnblockAllInteractions;
        _model.OnCommandAccepted += _view.BlockInteractions;

        _selectedValues.Subscribe(OnSelected);
    }
    private void OnSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        if (_currentSelectable != null)
        {
            _model.OnSelectionChanged();
        }
        _currentSelectable = selectable;

        _view.Clear();
        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
            var queue = (selectable as Component).GetComponentInParent<ICommandsQueue>();
            _view.MakeLayout(commandExecutors, queue);
        }
    }


}

}