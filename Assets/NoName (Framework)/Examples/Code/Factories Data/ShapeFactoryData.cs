using NoName.Factory;
using System;
using UnityEngine;

[System.Serializable]
public class ShapeFactoryData : AbstractFactoryData
{
    [SerializeField] private Shape _key;
    [SerializeField] private GameObject _value;

    public override Enum Key => _key;

    public override object Value => _value;
}
