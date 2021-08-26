using System;
using UnityEngine;

/// <summary>
/// Данные уровня - сетки ячеек
/// </summary>
[Serializable]
public struct GridLevelData
{
    [SerializeField] private int _gridRows;
    [SerializeField] private int _gridColumns;

    public int GridRows => _gridRows;
    public int GridColumns => _gridColumns;
}
