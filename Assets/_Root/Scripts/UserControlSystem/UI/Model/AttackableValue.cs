﻿using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "Strategy Game/" +
   nameof(AttackableValue), order = 4)]

public class AttackableValue : ScriptableObject
{
    public IAttackable CurrentValue { get; private set; }
    public Action<IAttackable> OnNewValue;

    public void SetValue(IAttackable value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);

    }
}

