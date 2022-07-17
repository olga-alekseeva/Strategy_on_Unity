using UnityEngine;

namespace Abstractions
{
    public interface ISelectable : IHealthValue, IIconHolder
    {
        Transform PivotPoint { get; }
        Material Material { get; }
    }
}


