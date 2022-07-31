using UniRx;

namespace Abstractions.Commands
{

    public interface IHealerUnitProducer 
    {
        IReadOnlyReactiveCollection<IHealerUnitProductionTask> Queue { get; }
        public void Cancel(int index);
    }
}
