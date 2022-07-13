using System;

namespace Utils
{

    public abstract class AwaiterBase<TAwaited> : IAwaiter<TAwaited>
    {
        private TAwaited _result;
        private bool _isCompleted;
        private Action _continuation;
        public bool IsCompleted => _isCompleted;

        public TAwaited GetResult() => _result;

        public void OnCompleted(Action continuation)
        {
            if (_isCompleted)
            {
                continuation?.Invoke();
            }
            else
            {
                _continuation = continuation;
            }
        }
        protected void onWaitingResult(TAwaited result)
        {
            _isCompleted = true;
            _result = result;
            _continuation?.Invoke();
        }
    }
}
