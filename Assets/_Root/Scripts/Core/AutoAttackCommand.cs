using Abstractions;
using Abstractions.Commands.CommandInterfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttackCommand : IAttackCommand
{
    public IAttackable Target { get; }

    public AutoAttackCommand (IAttackable target)
    {
        Target = target;
    }   
}
