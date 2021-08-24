using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ILevelCreation))]
public class LevelChanging : MonoBehaviour
{        
    [SerializeField] private InterfaceUpdater _interfaceUpdater;

    private int _currentLevel = 2;
    private ILevelCreation _levelCreator;
    private Card _currentGoal;
    
    void Start()
    {
        _levelCreator = GetComponent<ILevelCreation>();
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        _levelCreator.CreateLevel(_currentLevel);
        SelectGoal(_levelCreator.GetLevelCards());
        _currentLevel++;
    }

    private void SelectGoal(List<Card> cards)
    {
        _currentGoal = cards[Random.Range(0, cards.Count)];
        _interfaceUpdater.SetGoalText($"Find {_currentGoal.Identifier}");
    }
}
