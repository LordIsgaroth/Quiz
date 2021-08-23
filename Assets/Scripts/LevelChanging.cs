using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ILevelCreation))]
public class LevelChanging : MonoBehaviour
{    
    [SerializeField] private CardBundle[] _cardBundles;
    //[SerializeField] private GridGeneration _gridGenerator;


    private int _currentLevel = 0;
    private ILevelCreation _levelCreator;
    
    void Start()
    {
        _levelCreator = GetComponent<ILevelCreation>();
        _levelCreator.CreateLevel(_currentLevel);
    }       

    public void LoadLevel(int levelNumber)
    {
        CardBundle cardBundle = ChooseCardBundle();

        //Debug.Log(cardBundle);

        //LevelData level = _levels[levelNumber];
        //_gridGenerator.GenerateGrid(level.GridRows, level.GridColumns);
    }

    CardBundle ChooseCardBundle()
    {
        if (_cardBundles.Length == 0) throw new System.Exception("No card bundle specified!");

        int bundleNumber = Random.Range(0, _cardBundles.Length);
        return _cardBundles[bundleNumber];
    }
}
