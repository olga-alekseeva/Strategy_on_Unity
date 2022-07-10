using Abstractions.Commands;
using System;
using UnityEngine;
using UserControlSystem.UI.Model;
using Utils.AssetsInjector;
using Zenject;

namespace UI.Model.CommandCreators
{
    public class MoveCommandCommandCreator :
       CancellableCommandCreatorBase<IMoveCommand, Vector3>
    {
        protected override IMoveCommand createCommand(Vector3 argument) => new
        MoveCommand(argument);
    }
}
