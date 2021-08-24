using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[RequireComponent(typeof(ICardBundleGetter))]
public class GridLevelGenerator : MonoBehaviour, ILevelCreation
{
    [SerializeField] private GridLevelData[] _levels;
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private SpriteRenderer _gridBackground;
    [SerializeField] private float _gapBetweenCells;

    private ICardBundleGetter _cardBundleGetter;
    private ICardSelecting _cardSelector;
    private List<GameObject> _cells = new List<GameObject>();

    public void Awake()
    {
        _cardBundleGetter = GetComponent<ICardBundleGetter>();
    }

    public void CreateLevel(int number)
    {
        GridLevelData level = _levels[number];
        _cardSelector = new RandomUniqueCardSelector(_cardBundleGetter.ChooseCardBundle());

        GenerateGrid(level.GridRows, level.GridColumns, _cardSelector);
    }

    public void GenerateGrid(int rows, int columns, ICardSelecting cardBundle)
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
                _cells.Add(newCell);

                CardController _cellCardContrroller = newCell.GetComponent<CardController>();
                _cellCardContrroller.Card = cardBundle.SelectCard();

                currentY += _gapBetweenCells;
            }

            currentX += _gapBetweenCells;            
        }

        SetGridBackgroundSize(rows, columns);
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

    public List<Card> GetLevelCards()
    {
        return _cardSelector.GetAllSelectedCards();
    }
}

