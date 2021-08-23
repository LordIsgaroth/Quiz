using System.Collections.Generic;
using UnityEngine;

public class GridLevelGenerator : MonoBehaviour, ILevelCreation
{
    [SerializeField] private GridLevelData[] _levels;
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private SpriteRenderer _gridBackground;
    [SerializeField] private float _gapBetweenCells;    

    private List<Card> _cards = new List<Card>();

    public void CreateLevel(int number)
    {
        GridLevelData level = _levels[number];
        GenerateGrid(level.GridRows, level.GridColumns);
    }

    public void GenerateGrid(int rows, int columns)
    {
        float cellSizeX = _cellPrefab.transform.localScale.x;
        float cellSizeY = _cellPrefab.transform.localScale.y;

        float startX = -(cellSizeX * (columns - 1) + _gapBetweenCells * (columns - 1)) / 2;
        float startY = -(cellSizeY * (rows - 1) + _gapBetweenCells * (rows - 1)) / 2;

        float currentX = startX;
        float currentY = startY;        

        for (int x = 0; x < columns; x++)
        {            
            currentY = startY;

            for (int y = 0; y < rows; y++)
            {               
                GameObject newCell = Instantiate(_cellPrefab, new Vector3(currentX + (cellSizeX * x), currentY + (cellSizeY * y), 0), _cellPrefab.transform.rotation);
                //_cells.Add(newCell);
                currentY += _gapBetweenCells;
            }

            currentX += _gapBetweenCells;            
        }

        SetGridBackgroundSize(rows, columns);
    }

    public IReadOnlyCollection<Card> GetLevelCards()
    {
        return _cards.AsReadOnly();
    }

    private void SetGridBackgroundSize(int rows, int columns)
    {
        float cellSizeX = _cellPrefab.transform.localScale.x;
        float cellSizeY = _cellPrefab.transform.localScale.y;

        _gridBackground.transform.localScale = new Vector2((cellSizeX * columns) + (_gapBetweenCells * (columns + 1)), (cellSizeY * rows) + (_gapBetweenCells * (rows + 1)));
    }

    public int GetNumberOfLevels()
    {
        return _levels.Length;
    }
}

