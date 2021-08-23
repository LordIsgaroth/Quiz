using System;
using UnityEngine;

[Serializable]
public struct GridLevelData
{
    [SerializeField] private int _gridRows;
    [SerializeField] private int _gridColumns;

    public int GridRows => _gridRows;
    public int GridColumns => _gridColumns;
}
