using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ICardBundleGetter))]
public class GridLevelGenerator : MonoBehaviour, ILevelCreation
{
    [SerializeField] private GridLevelData[] _levels;
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private SpriteRenderer _gridBackground;
    [SerializeField] private float _gapBetweenCells;

    private bool _createWithAnimation;
    private ICardBundleGetter _cardBundleGetter;
    private ICardSelecting _cardSelector;
    private UnityAction<CellController> _cardChooseDispatcher;
    private List<Card> _cardsToExclude;
    private List<GameObject> _cells = new List<GameObject>();

    public void Awake()
    {
        _cardBundleGetter = GetComponent<ICardBundleGetter>();
    }

    public void CreateLevel(int number, List<Card> cardsToExclude, UnityAction<CellController> cardChooseDispatcher)
    {
        GridLevelData level = _levels[number - 1];
        _cardSelector = new RandomUniqueCardSelector(_cardBundleGetter.ChooseCardBundle());
        _cardChooseDispatcher = cardChooseDispatcher;
        _cardsToExclude = cardsToExclude;

        if (number == 1) _createWithAnimation = true;
        else _createWithAnimation = false;

        ClearCurrentLevel();
        GenerateGrid(level);
    }

    public void GenerateGrid(GridLevelData level)
    {
        int rows = level.GridRows;
        int columns = level.GridColumns;

        SetGridBackgroundSize(rows, columns);

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

                CellController cellContrroller = newCell.GetComponent<CellController>();
                cellContrroller.Card = _cardSelector.SelectCard(_cardsToExclude);
                cellContrroller.OnCardChoose.AddListener(_cardChooseDispatcher);

                if (_createWithAnimation) cellContrroller.Bounce();

                currentY += _gapBetweenCells;
            }

            currentX += _gapBetweenCells;            
        }        
    }    

    private void SetGridBackgroundSize(int rows, int columns)
    {
        float cellSizeX = _cellPrefab.transform.localScale.x;
        float cellSizeY = _cellPrefab.transform.localScale.y;

        _gridBackground.transform.localScale = new Vector2((cellSizeX * columns) + (_gapBetweenCells * (columns + 1)), (cellSizeY * rows) + (_gapBetweenCells * (rows + 1)));
    }

    private void ClearCurrentLevel()
    {
        foreach(GameObject cell in _cells)
        {
            CellController cellContrroller = cell.GetComponent<CellController>();
            cellContrroller.OnCardChoose.RemoveListener(_cardChooseDispatcher);
            Destroy(cell);
        }

        _cells.Clear();
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

