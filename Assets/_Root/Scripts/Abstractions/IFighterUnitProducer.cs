using UniRx;

namespace Abstractions.Commands
{

public interface IFighterUnitProducer 
{
        IReadOnlyReactiveCollection<IFighterUnitProductionTask> Queue { get; }
        public void Cancel(int index);
    }
}
