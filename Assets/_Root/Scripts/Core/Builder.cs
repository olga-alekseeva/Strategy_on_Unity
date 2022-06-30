using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour, ISelectable
{
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Material _material;
    public float Health => throw new System.NotImplementedException();

    public float MaxHealth => throw new System.NotImplementedException();

    public Sprite Icon => throw new System.NotImplementedException();

    public Material Material => throw new System.NotImplementedException();
}
