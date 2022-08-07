using Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(HealableValue), menuName = "Strategy Game/" + nameof(HealableValue), order = 5)]
    public sealed class HealableValue : StatelessScriptableObjectValueBase<IHealable>
    {
    }
}
