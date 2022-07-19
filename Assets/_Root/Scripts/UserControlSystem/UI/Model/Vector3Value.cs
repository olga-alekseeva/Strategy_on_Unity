using Abstractions;
using UnityEngine;

namespace UserControlSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(Vector3Value), menuName = "Strategy Game/"
+ nameof(Vector3Value), order = 3)]
    public sealed class Vector3Value : StatelessScriptableObjectValueBase<Vector3>
    {

    }
}

