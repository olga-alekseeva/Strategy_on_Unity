using System;
using System.Collections.Generic;
using UnityEngine;

public interface IGameStatus 
{
    IObservable<int> Status { get; }
}
