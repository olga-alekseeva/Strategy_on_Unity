using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour, ISelectable, IChangeColour
{
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Material _material;
    private float _health = 1000;
    public float Health => _health;

    public float MaxHealth => _maxHealth;

    public Sprite Icon => _icon;

    public Material Material => _material;

    public void ChangeColour()
    {
        throw new System.NotImplementedException();
    }
}
