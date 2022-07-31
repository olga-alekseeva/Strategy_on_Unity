using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abstractions;

namespace Core
{

    public class UnitProductionTask : IFighterUnitProductionTask
    {
        public Sprite Icon { get; }
        public float TimeLeft { get; set; }
        public float ProductionTime { get; }
        public string UnitName { get; }
        public GameObject UnitPrefab { get; }

        public UnitProductionTask(float time, Sprite icon, GameObject unitPrefab, string unitName)
        {
            Icon = icon;
            ProductionTime = time;
            TimeLeft = time;
            UnitName = unitName;
            UnitPrefab = unitPrefab;

        }
    }
}
