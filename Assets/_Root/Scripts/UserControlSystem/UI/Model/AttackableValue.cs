using Abstractions;
using UnityEngine;

namespace UserControlSystem.UI.Model
{

    [CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "Strategy Game/" +
   nameof(AttackableValue), order = 4)]

    public class AttackableValue : ScriptableObjectValueBase<IAttackable>
    {
    }
}

