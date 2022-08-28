using Abstractions;
using System;
using UnityEngine;

namespace UserControlSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(Vector3Value), menuName = "Strategy Game/"
+ nameof(Vector3Value), order = 3)]
    public class Vector3Value : ScriptableObjectValueBase<Vector3>
    {

    }
}

