using Abstractions.Commands.CommandInterfaces;
using System.Threading.Tasks;
using UnityEngine;

namespace Abstractions.Commands.CommandExecutors
{

    public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {
        public override async Task ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log("I attack");
        }
    }
}
