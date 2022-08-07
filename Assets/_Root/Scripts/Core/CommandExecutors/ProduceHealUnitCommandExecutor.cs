using Abstractions;
using Abstractions.Commands;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core.CommandExecutors
{
    public class ProduceHealUnitCommandExecutor : CommandExecutorBase<IProduceHealUnitCommand>, IUnitProducer
    {
        public IReadOnlyReactiveCollection<IUnitProductionTask> Queue => _queue;

        [SerializeField] private Transform _unitsParent;
        [SerializeField] private int _maximumUnitsInQueue = 6;
        [Inject] private DiContainer _diContainer;

        private ReactiveCollection<IUnitProductionTask> _queue = new ReactiveCollection<IUnitProductionTask>();

        private void Update()
        {
            if (_queue.Count == 0)
            {
                return;
            }

            var innerTask = (UnitProductionTask)_queue[0];
            innerTask.TimeLeft -= Time.deltaTime;
            if (innerTask.TimeLeft <= 0)
            {
                RemoveTaskAtIndex(0);
                Instantiate(innerTask.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
            }
        }

        public void Cancel(int index) => RemoveTaskAtIndex(index);

        private void RemoveTaskAtIndex(int index)
        {
            for (int i = index; i < _queue.Count - 1; i++)
            {
                _queue[i] = _queue[i + 1];
            }
            _queue.RemoveAt(_queue.Count - 1);
        }

        public override async Task ExecuteSpecificCommand(IProduceHealUnitCommand command)
        {
            var instance = _diContainer.InstantiatePrefab(command.UnitPrefab, transform.position, Quaternion.identity, _unitsParent);
            var queue = instance.GetComponent<ICommandsQueue>();
            var mainBuilding = GetComponent<Hospital>();
            var factionMember = instance.GetComponent<FactionMember>();
            factionMember.SetFaction(GetComponent<FactionMember>().FactionId);
            queue.EnqueueCommand(new MoveCommand(mainBuilding.RallyPoint));
        }
    }
}

