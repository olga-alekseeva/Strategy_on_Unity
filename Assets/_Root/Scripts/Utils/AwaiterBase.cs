using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{

    public abstract class AwaiterBase<TAwaited> : IAwaiter<TAwaited>
    {
        public bool IsCompleted => throw new NotImplementedException();

        public TAwaited GetResult()
        {
            throw new NotImplementedException();
        }

        public void OnCompleted(Action continuation)
        {
            throw new NotImplementedException();
        }
    }
}
