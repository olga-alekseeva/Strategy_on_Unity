using UnityEngine;

namespace Abstractions
{
 public interface ISelectable : IHealthValue
 {
        Transform PivotPoint { get; }
        Sprite Icon { get; }
        Material Material { get; }
 }
}


