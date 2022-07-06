using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abstractions.Commands;
using Abstractions;

public class Hare :MonoBehaviour, ISelectable
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Material _material;
    private float _health = 100;
    public float Health => _health;

    public float MaxHealth => _maxHealth;

    public Sprite Icon => _icon;

    public Material Material => _material;
 
}
