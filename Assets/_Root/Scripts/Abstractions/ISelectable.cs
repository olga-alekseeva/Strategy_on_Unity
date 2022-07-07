using UnityEngine;
 public interface ISelectable : IHealthValue
 {
        Transform PivotPoint { get; }
        Sprite Icon { get; }
        Material Material { get; }
 }


