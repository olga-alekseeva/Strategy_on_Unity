using Abstractions.Commands;
using Core;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Utils;
namespace Abstractions.Commands.CommandExecutors
{

    public class ProduceResourcesCommandExecutor : CommandExecutorBase<IProduceResourcesCommand>
    {
        public override Task ExecuteSpecificCommand(IProduceResourcesCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
