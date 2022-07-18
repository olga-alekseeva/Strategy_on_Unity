using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Abstractions.Commands.CommandExecutors
{
    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommandExecutor;
        public override async Task ExecuteSpecificCommand(IMoveCommand command)
        {
            GetComponent<NavMeshAgent>().destination = command.Target;
            _animator.SetTrigger("Walk");
            _stopCommandExecutor.cancellationTokenSource = new CancellationTokenSource();
            try
            {
                await _stop.WithCancellation(_stopCommandExecutor.cancellationTokenSource.Token);
            }
            catch
            {
                GetComponent<NavMeshAgent>().isStopped = true;
                GetComponent<NavMeshAgent>().ResetPath();
            }
            _stopCommandExecutor.cancellationTokenSource = null;
            _animator.SetTrigger("Idle");
        }
    }
}