using System;
using System.Threading;
using System.Threading.Tasks;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandExecutors;
using Abstractions.Commands.CommandInterfaces;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Utils;
using Zenject;
using static Core.CommandExecutors.AttackCommandExecutor;

namespace Core.CommandExecutors
{
    public class HealCommandExecutor : CommandExecutorBase<IHealCommand>
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommandExecutor;

        [Inject] private IHealthValue _ourHealth;
        [Inject(Id = "AttackDistance")] private float _healingDistance;
        [Inject(Id = "AttackPeriod")] private int _healingPeriod;

        private Vector3 _ourPosition;
        private Vector3 _targetPosition;
        private Quaternion _ourRotation;

        private readonly Subject<Vector3> _targetPositions = new Subject<Vector3>();
        private readonly Subject<Quaternion> _targetRotations = new Subject<Quaternion>();
        private readonly Subject<IAttackable> _healTargets = new Subject<IAttackable>();

        private Transform _targetTransform;
        private HealOperation _currentHealOp;

        [Inject]
        private void Init()
        {
            _targetPositions
                .Select(value => new Vector3((float)Math.Round(value.x, 2), (float)Math.Round(value.y, 2), (float)Math.Round(value.z, 2)))
                .Distinct()
                .ObserveOnMainThread()
                .Subscribe(StartMovingToPosition);

            _healTargets
                .ObserveOnMainThread()
                .Subscribe(StartHealingTargets);

            _targetRotations
                .ObserveOnMainThread()
                .Subscribe(SetHealRotation);
        }

        private void SetHealRotation(Quaternion targetRotation)
        {
            transform.rotation = targetRotation;
        }

        private void StartHealingTargets(IAttackable target)
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            GetComponent<NavMeshAgent>().ResetPath();
            _animator.SetTrigger(Animator.StringToHash("Attack"));
            target.ReceiveHeal(GetComponent<IDamageDealer>().Damage);
        }

        private void StartMovingToPosition(Vector3 position)
        {
            GetComponent<NavMeshAgent>().destination = position;
            _animator.SetTrigger(Animator.StringToHash("Walk"));
        }

        public override async Task ExecuteSpecificCommand(IHealCommand command)
        {
            _targetTransform = (command.Target as Component).transform;
            _currentHealOp = new HealOperation(this, command.Target);
            Update();
            _stopCommandExecutor.CancellationTokenSource = new CancellationTokenSource();
            try
            {
                await _currentHealOp.WithCancellation(_stopCommandExecutor.CancellationTokenSource.Token);
            }
            catch
            {
                _currentHealOp.Cancel();
            }
            _animator.SetTrigger("Idle");
            _currentHealOp = null;
            _targetTransform = null;
            _stopCommandExecutor.CancellationTokenSource = null;
        }

        private void Update()
        {
            if (_currentHealOp == null)
            {
                return;
            }

            //lock(this)
            {
                _ourPosition = transform.position;
                _ourRotation = transform.rotation;
                if (_targetTransform != null)
                {
                    _targetPosition = _targetTransform.position;
                }
            }
        }

        #region HealOperation

        public sealed class HealOperation : IAwaitable<AsyncExtensions.Void>
        {
            public class HealOperationAwaiter : AwaiterBase<AsyncExtensions.Void>
            {
                private HealOperation _healOperation;

                public HealOperationAwaiter(HealOperation healOperation)
                {
                    _healOperation = healOperation;
                    healOperation.OnComplete += OnComplete;
                }

                private void OnComplete()
                {
                    _healOperation.OnComplete -= OnComplete;
                    OnWaitingResult(new AsyncExtensions.Void());
                }
            }

            private event Action OnComplete;

            private readonly HealCommandExecutor _healCommandExecutor;
            private readonly IAttackable _target;

            private bool _isCancelled;

            public HealOperation(HealCommandExecutor healCommandExecutor, IAttackable target)
            {
                _target = target;
                _healCommandExecutor = healCommandExecutor;

                var thread = new Thread(HealAlgorythm);
                thread.Start();
            }

            public void Cancel()
            {
                _isCancelled = true;
                OnComplete?.Invoke();
            }

            private void HealAlgorythm(object obj)
            {
                while (true)
                {
                    if (
                        _healCommandExecutor == null
                        || _healCommandExecutor._ourHealth.Health == 100
                        || _target.Health == 100
                        || _isCancelled
                        )
                    {
                        OnComplete?.Invoke();
                        return;
                    }

                    var targetPosition = default(Vector3);
                    var ourPosition = default(Vector3);
                    var ourRotation = default(Quaternion);
                    //lock (_healCommandExecutor)
                    {
                        targetPosition = _healCommandExecutor._targetPosition;
                        ourPosition = _healCommandExecutor._ourPosition;
                        ourRotation = _healCommandExecutor._ourRotation;
                    }

                    var vector = targetPosition - ourPosition;
                    var distanceToTarget = vector.magnitude;
                    if (distanceToTarget > _healCommandExecutor._healingDistance)
                    {
                        var finalDestination = targetPosition - vector.normalized * (_healCommandExecutor._healingDistance * 0.9f);
                        _healCommandExecutor
                    ._targetPositions.OnNext(finalDestination);
                        Thread.Sleep(100);
                    }
                    else if (ourRotation != Quaternion.LookRotation(vector))
                    {
                        _healCommandExecutor.
                    _targetRotations
                    .OnNext(Quaternion.LookRotation(vector));
                    }
                    else
                    {
                        _healCommandExecutor._healTargets.OnNext(_target);
                        Thread.Sleep(_healCommandExecutor._healingPeriod);
                    }
                }
            }

            public IAwaiter<AsyncExtensions.Void> GetAwaiter()
            {
                return new HealOperationAwaiter(this);
            }
        }

        #endregion
    }

}

