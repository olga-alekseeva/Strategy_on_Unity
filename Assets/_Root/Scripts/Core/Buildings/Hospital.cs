using Abstractions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{

public class Hospital : MonoBehaviour, ISelectable, IAttackable
{
        public Transform PivotPoint => _pivotPoint;

        public float Health => _health;

        public float MaxHealth => _maxHealth;

        public Vector3 RallyPoint { get; set; }
        public Sprite Icon => _icon;

        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;

        private float _health = 100;

        public void ReceiveDamage(int amount)
        {
            if (_health <= 0)
            {
                return;
            }
            _health -= amount;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void ReceiveHeal(int amount)
        {
           
        }
    }
}
