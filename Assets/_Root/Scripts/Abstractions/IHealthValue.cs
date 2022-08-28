using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstractions
{

public interface IHealthValue 
{
    int Health { get; }
    int MaxHealth { get; }
}
}
