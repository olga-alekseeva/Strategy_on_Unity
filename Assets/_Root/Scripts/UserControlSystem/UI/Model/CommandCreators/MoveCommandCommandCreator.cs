using Abstractions.Commands;
using UnityEngine;

namespace UI.Model.CommandCreators
{
    public class MoveCommandCommandCreator :
       CancellableCommandCreatorBase<IMoveCommand, Vector3>
    {
        protected override IMoveCommand createCommand(Vector3 argument) => new
        MoveCommand(argument);
    }
}
