using Abstractions.Commands;
using UnityEngine;
using UserControlSystem.UI.Model;
using Zenject;

namespace UI.Model.CommandCreators
{
    internal class PatrolCommandCommandCreator :
       CancellableCommandCreatorBase<IPatrolCommand, Vector3>
    {
        [Inject] private SelectableValue _selectable;
        protected override IPatrolCommand createCommand(Vector3 argument) => new
        PatrolCommand(_selectable.CurrentValue.PivotPoint.position, argument);
    }
}

