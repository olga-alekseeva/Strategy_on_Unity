using UnityEngine;

namespace Abstractions.Commands
{
    public interface IPatrolCommand : ICommand
    {
        public Vector3 From { get; }
        public Vector3 To { get; }
    }
}