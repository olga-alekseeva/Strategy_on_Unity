using Abstractions.Commands;
using UnityEngine;

namespace Core
{

    public class MoveCommand : IMoveCommand
    {
        public Vector3 Target { get; }
        public MoveCommand(Vector3 target)
        {
            Target = target;
        }

    }
}
