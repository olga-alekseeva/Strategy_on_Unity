using Abstractions;
using System;
using UnityEngine;

namespace UserControlSystem.UI.Model
{

    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" +
    nameof(SelectableValue), order = 0)]
    public class SelectableValue : ScriptableObjectValueBase<ISelectable>
    {
    }
}


