using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceUnitCommand : IProduceUnitCommand
{
    [SerializeField] private GameObject _unitPrefab;    
    public GameObject UnitPrefab => _unitPrefab;
}
