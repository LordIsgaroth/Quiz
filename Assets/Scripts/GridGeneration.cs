using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGeneration : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private SpriteRenderer _gridBackground;
    [SerializeField] private float _gapBetweenCells;
    
    private void Start()
    {
        GenerateGrid(3,1);
    }   

    private void GenerateGrid(int sizeX, int sizeY)
    {
        float cellSizeX = _cellPrefab.transform.localScale.x;
        float cellSizeY = _cellPrefab.transform.localScale.y;

        float startX = -(cellSizeX * (sizeX - 1) + _gapBetweenCells * (sizeX - 1)) / 2;
        float startY = -(cellSizeY * (sizeY - 1) + _gapBetweenCells * (sizeY - 1)) / 2;

        Debug.Log(startX);
        Debug.Log(startY);

        float currentX = startX;
        float currentY = startY;        

        for (int x = 0; x < sizeX; x++)
        {            
            currentY = startY;

            for (int y = 0; y < sizeY; y++)
            {               
                GameObject newTile = Instantiate(_cellPrefab, new Vector3(currentX + (cellSizeX * x), currentY + (cellSizeY * y), 0), _cellPrefab.transform.rotation);
                currentY += _gapBetweenCells;
            }

            currentX += _gapBetweenCells;            
        }

        SetGridBackgroundSize(sizeX, sizeY);
    }

    private void SetGridBackgroundSize(int sizeX, int sizeY)
    {
        float cellSizeX = _cellPrefab.transform.localScale.x;
        float cellSizeY = _cellPrefab.transform.localScale.y;

        _gridBackground.transform.localScale = new Vector2((cellSizeX * sizeX) + (_gapBetweenCells * (sizeX + 1)), (cellSizeY * sizeY) + (_gapBetweenCells * (sizeY + 1)));
    }
}
