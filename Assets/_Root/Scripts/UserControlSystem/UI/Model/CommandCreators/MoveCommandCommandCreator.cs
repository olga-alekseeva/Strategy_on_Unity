using Abstractions.Commands;
using UnityEngine;

namespace UserControlSystem
{
    public class MoveCommandCommandCreator :
       CancellableCommandCreatorBase<IMoveCommand, Vector3>
    {
        protected override IMoveCommand CreateCommand(Vector3 argument) => new
        MoveCommand(argument);
    }
}
